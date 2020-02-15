using Microsoft.EntityFrameworkCore.Query;
using ProcessInfo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
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

        int Count(Expression<Func<T, bool>> predicate = null);

        List<T> FindWithInclude(
          Expression<Func<T, bool>> filter = null,
          string orderBy = null,
          FCSortDirection? sortDirection = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                          int? start = null, int? length = null, bool disableTracking = true);

        T FirstOrDefaultWithInclude(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
