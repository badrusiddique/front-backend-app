using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sample.Data;
using Sample.Data.Entities;
using Sample.Orchestrator.Repositories.Interfaces;

namespace Sample.Orchestrator.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDatabaseContext _databaseContext;

        public Repository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        #region Public Methods

        public async ValueTask<TEntity> FindAsync(Guid id) => await _databaseContext.Set<TEntity>().FindAsync(id);

        public IQueryable<TEntity> All() => _databaseContext.Set<TEntity>();

        public async ValueTask<TEntity> CreateAndSaveAsync(TEntity entity)
        {
            var createdEntity = await _databaseContext.Set<TEntity>().AddAsync(entity);
            await CommitChangesAsync();

            return createdEntity?.Entity;
        }

        public async ValueTask<int> UpdateAndSaveAsync<TKEntity>(TKEntity entity) where TKEntity : BaseEntity
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _databaseContext.Set<TKEntity>().Attach(entity);
            _databaseContext.ChangeEntityState(entity, EntityState.Modified);

            return await CommitChangesAsync();
        }

        public async ValueTask<int> DeleteAndSaveAsync<TKEntity>(TKEntity entity) where TKEntity : BaseEntity
        {
            _databaseContext.Set<TKEntity>().Attach(entity);
            entity.IsInactive = true;
            entity.UpdatedAt = DateTime.UtcNow;
            _databaseContext.ChangeEntityState(entity, EntityState.Modified);

            return await CommitChangesAsync();
        }

        public async ValueTask<int> CommitChangesAsync() => await _databaseContext.CommitChangesAsync();

        public async ValueTask<int> CommitChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
            => await _databaseContext.CommitChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        #endregion
    }
}