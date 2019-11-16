using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessInfo.Service.Interfaces
{
    public interface IEntityService<T>
    {
        bool Create(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
