﻿using PetProject.Server.Core.Entities;
using System.Linq.Expressions;

namespace PetProject.Server.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity, long userId);
        void AddRange(ICollection<TEntity> entities, long userId);
        Task<TEntity> AddAsync(TEntity entity, long userId, CancellationToken cancellationToken = default);
        Task AddRangeAsync(ICollection<TEntity> entities, long userId, CancellationToken cancellationToken = default);
        TEntity Update(TEntity entity, long userId);
        void UpdateRange(ICollection<TEntity> entities, long userId);
        void Delete(object id);
        void Delete(TEntity entity);
        void DeleteRange(ICollection<TEntity> entities);
        TEntity? Find(params object[] keyValues);
        ValueTask<TEntity?> FindAsync(params object[] keyValues);
        ValueTask<TEntity?> FindAsync(object[] keyValues, CancellationToken cancellationToken);
        IQueryable<TEntity> Queryable();
        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties);
    }
}
