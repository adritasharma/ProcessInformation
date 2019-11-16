using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProcessInfo.Repository.Interfaces;
using ProcessInfo.DB.Models;

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
    }
}
