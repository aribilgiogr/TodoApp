using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Utilities.Generics
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public bool Any(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? _dbSet.Any(predicate) : _dbSet.Any();
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? _dbSet.Count(predicate) : _dbSet.Count();
        }

        public T Find(object entityKey)
        {
            return _dbSet.Find(entityKey);
        }

        public T FindFirst(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            return FindMany(predicate, includes).FirstOrDefault();
        }

        public IEnumerable<T> FindMany(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            IQueryable<T> data = predicate!=null ? _dbSet.Where(predicate) : _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    data = data.Include(include);
                }
            }
            return data;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
