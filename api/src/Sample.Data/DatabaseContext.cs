using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Sample.Common.Extensions;
using Sample.Data.Entities;
using Sample.Data.Utils;

namespace Sample.Data
{
    public sealed class DatabaseContext : DbContext, IDatabaseContext
    {
        #region Private Variables

        private readonly ILogger<DatabaseContext> _logger;

        #endregion

        #region Constructor

        public DatabaseContext(DbContextOptions options, ILogger<DatabaseContext> logger)
            : base(options)
        {
            _logger = logger;
            var connection = Database.GetDbConnection();
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            _logger.LogInformation($"Sample Database connection using: {connection.ConnectionString} for {envName} env");
        }

        #endregion

        #region DbSets

        public DbSet<Audit> Audits { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        #endregion

        #region Public Methods

        public void ChangeEntityState(object entity, EntityState state)
        {
            Entry(entity).State = state;
        }

        public new EntityEntry Entry<TEntity>(TEntity entity) where TEntity : class => base.Entry(entity);

        public async ValueTask<int> CommitChangesAsync() => await CommitChangesAsync(true, default);

        public async ValueTask<int> CommitChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            try
            {
                var auditEntries = OnBeforeSaveChanges();
                var result = await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
                await OnAfterSaveChanges(auditEntries);
                return result;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"An error is encountered while saving to the database: {ex.Message}", JsonCovertExtension.SerializeObject(ex));
                throw;
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

        #endregion

        #region Private Methods

        private IList<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();

            var auditEntries = AuditUtil.MapEntityToAuditEntries(ChangeTracker.Entries());

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                Audits.Add(auditEntry.ToAudit());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        private Task OnAfterSaveChanges(IList<AuditEntry> auditEntries)
        {
            if (auditEntries == null || !auditEntries.Any())
            {
                return Task.CompletedTask;
            }

            Audits.AddRange(AuditUtil.MapAuditEntryToAudit(auditEntries));
            return SaveChangesAsync();
        }

        #endregion
    }
}