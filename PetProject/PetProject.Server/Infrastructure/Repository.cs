﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PetProject.Server.Core.Entities;
using PetProject.Server.Core.Interfaces;
using System.Linq.Expressions;

namespace PetProject.Server.Infrastructure
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly PetProjectContext _context;
        public Repository(PetProjectContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual TEntity Update(TEntity entity, long userId)
        {
            SetBaseValueUpdate(entity, userId);
            return _dbSet.Update(entity).Entity;
        }

        public virtual void UpdateRange(ICollection<TEntity> entities, long userId)
        {
            var enumerable = entities.AsEnumerable().Select(s =>
            {
                SetBaseValueUpdate(s, userId);
                return s;
            });
            _dbSet.UpdateRange(enumerable);
        }
        private void SetBaseValueUpdate(TEntity entity, long userId)
        {
            entity.UpdatedId = userId;
            entity.UpdatedTime = DateTime.UtcNow;
        }

        public virtual TEntity? Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public virtual ValueTask<TEntity?> FindAsync(params object[] keyValues)
        {
            return _dbSet.FindAsync(keyValues);
        }

        public virtual ValueTask<TEntity?> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return _dbSet.FindAsync(cancellationToken, keyValues);
        }

        public virtual TEntity Insert(TEntity entity, long userId)
        {
            SetBaseValueInsert(entity, userId);
            return _dbSet.Add(entity).Entity;
        }
        private void SetBaseValueInsert(TEntity entity, long userId)
        {
            entity.CreatedId = userId;
            entity.CreatedTime = DateTime.UtcNow;
        }

        public virtual void InsertRange(ICollection<TEntity> entities, long userId)
        {
            var enumerable = entities.Select(entity =>
            {
                SetBaseValueInsert(entity, userId);
                return entity;
            }).AsEnumerable();
            _dbSet.AddRange(enumerable);
        }

        public virtual ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity, long userId, CancellationToken cancellationToken = default)
        {
            SetBaseValueInsert(entity, userId);
            return _dbSet.AddAsync(entity, cancellationToken);
        }

        public virtual Task InsertRangeAsync(ICollection<TEntity> entities, long userId, CancellationToken cancellationToken = default)
        {
            var enumerable = entities.AsEnumerable().Select(s =>
            {
                SetBaseValueInsert(s, userId);
                return s;
            });
            return _dbSet.AddRangeAsync(enumerable, cancellationToken);
        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) return;
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void DeleteRange(ICollection<TEntity> entities)
        {
            var enumerable = entities.AsEnumerable();
            _dbSet.RemoveRange(enumerable);
        }

        public virtual IQueryable<TEntity> Queryable()
        {
            return _dbSet.AsQueryable();
        }

        public virtual IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate)
        {
            return Queryable().Where(predicate);
        }

        public virtual IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            return orderBy(Queryable(predicate));
        }

        public virtual IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties)
        {
            var result = Queryable(predicate, orderBy);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                result = result.Include(includeProperty);
            }
            return result;
        }
    }
}
