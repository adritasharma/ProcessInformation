using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProcessInfo.Repository.Interfaces;
using ProcessInfo.Service.Interfaces;

namespace ProcessInfo.Service.Implementations
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        protected IGenericRepository<T> Repository;
        protected IUnitOfWork UnitOfWork;

        public EntityService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public bool Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Repository.Add(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Repository.Delete(entity);
            return true;
        }


        public IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public T GetById(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return Repository.GetById(id);

        }
        public bool Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Repository.Edit(entity);
            return true;
        }

    }
}
