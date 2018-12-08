using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Domains.Interfaces;
using System;
using System.Threading.Tasks;

namespace SAX.CoreLibrary.UnitOfWork
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool disposed = false;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing) _context.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
