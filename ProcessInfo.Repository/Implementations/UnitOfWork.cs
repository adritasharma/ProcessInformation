using System;
using System.Collections.Generic;
using System.Text;
using ProcessInfo.DB.Models;
using ProcessInfo.Repository.Interfaces;

namespace ProcessInfo.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProcessInfoDbContext _context;

        public UnitOfWork(ProcessInfoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
            _context = null;
        }

    }
}
