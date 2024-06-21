using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sample.Data.Entities;

namespace Sample.Orchestrator.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get TEntity record by id from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TEntity> FindAsync(Guid id);

        /// <summary>
        /// Get TEntity records from the database
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> All();

        /// <summary>
        /// Create TEntity record and save asynchronously
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>TEntity</returns>
        ValueTask<TEntity> CreateAndSaveAsync(TEntity entity);

        /// <summary>
        /// Update BaseEntity TKEntity record and save asynchronously
        /// </summary>
        /// <param name="entity">BaseEntity</param>
        /// <returns></returns>
        ValueTask<int> UpdateAndSaveAsync<TKEntity>(TKEntity entity) where TKEntity : BaseEntity;

        /// <summary>
        /// Delete BaseEntity TKEntity  record and save asynchronously
        /// </summary>
        /// <param name="entity">BaseEntity></param>
        /// <returns></returns>
        ValueTask<int> DeleteAndSaveAsync<TKEntity>(TKEntity entity) where TKEntity : BaseEntity;

        /// <summary>
        /// Save to database asynchronously
        /// </summary>
        /// <returns></returns>
        ValueTask<int> CommitChangesAsync();

        /// <summary>
        /// Save to database asynchronously using cancellation-token
        /// </summary>
        /// <returns></returns>
        ValueTask<int> CommitChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
    }
}