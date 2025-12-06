using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Utilities.Generics
{
    public interface IRepository<T> where T : class
    {
        T Find(object entityKey);
        T FindFirst(Expression<Func<T, bool>> predicate = null, params string[] includes);
        IEnumerable<T> FindMany(Expression<Func<T, bool>> predicate = null, params string[] includes);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        int Count(Expression<Func<T, bool>> predicate = null);
        bool Any(Expression<Func<T, bool>> predicate = null);
    }
}
