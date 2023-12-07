using PetProject.Server.Core.Entities;
using PetProject.Server.Core.Interfaces;
using System.Linq.Expressions;

namespace PetProject.Server.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private PetProjectContext _context;
        public Repository(PetProjectContext context)
        {
            this._context = context;
            
        }
        public TEntity Add(TEntity entity, long userId)
        {
            entity.CreatedId = userId;
            entity.CreatedTime= DateTime.UtcNow;
            return this._context.Add(entity).Entity;
        }

        public Task<TEntity> AddAsync(TEntity entity, long userId, CancellationToken cancellationToken = default)
        {
            entity.CreatedId = userId;
            entity.CreatedTime = DateTime.UtcNow;
            return this._context.AddAsync(entity).AsTask();
        }

        public void AddRange(ICollection<TEntity> entities, long userId)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(ICollection<TEntity> entities, long userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(ICollection<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity? Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity?> FindAsync(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity?> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Queryable()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity, long userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(ICollection<TEntity> entities, long userId)
        {
            throw new NotImplementedException();
        }
    }
}
