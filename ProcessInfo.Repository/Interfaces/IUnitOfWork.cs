using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessInfo.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
        void Dispose(bool disposing);
    }
}
