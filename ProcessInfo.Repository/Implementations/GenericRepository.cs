using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProcessInfo.Repository.Interfaces;
using ProcessInfo.DB.Models;
using Microsoft.EntityFrameworkCore.Query;
using ProcessInfo.Utility;
using System.Linq.Dynamic.Core;

namespace ProcessInfo.Repository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ProcessInfoDbContext _context;
        protected DbSet<T> DbSet;

        public GenericRepository(ProcessInfoDbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return DbSet.AsEnumerable<T>();
        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return DbSet.FirstOrDefault();
            else
                return DbSet.FirstOrDefault(predicate);
        }
        public T Add(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            DbSet.Remove(entity);
            return entity;
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public bool Any(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return DbSet.Any();
            else
                return DbSet.Any(predicate);
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return DbSet.Count();
            else
                return DbSet.Count(predicate);
        }


        public virtual List<T> FindWithInclude(
         Expression<Func<T, bool>> filter = null,
        string orderBy = null,
        FCSortDirection? sortDirection = null,
         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                         int? start = null, int? length = null, bool disableTracking = true)
        {
            IQueryable<T> query = DbSet;

            if (disableTracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (include != null)
                query = include(query);

            if (orderBy != null)
            {
                if (sortDirection == FCSortDirection.Descending)
                {
                    query = query.OrderBy(orderBy + " descending");
                }
                else
                {
                    query = query.OrderBy(orderBy);
                }
            }


            if (start.HasValue)
            {
                var skipValue = start.Value;
                query = query.Skip(skipValue);
            }
            if (length.HasValue)
            {
                var takeValue = length.Value;
                query = query.Take(takeValue);
            }
            return query.ToList();
        }

        public T FirstOrDefaultWithInclude(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = DbSet;
            if (include != null)
                query = include(query);

            if (predicate == null)
                return query.FirstOrDefault();
            else
                return query.FirstOrDefault(predicate);
        }
    }
}
