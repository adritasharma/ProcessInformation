using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProcessInfo.Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        T GetById(object id);
        IEnumerable<T> GetAll();
        T FirstOrDefault(Expression<Func<T, bool>> predicate = null);
        T Add(T entity);
        void Edit(T entity);
        T Delete(T entity);
        bool Any(Expression<Func<T, bool>> predicate = null);
    }
}
