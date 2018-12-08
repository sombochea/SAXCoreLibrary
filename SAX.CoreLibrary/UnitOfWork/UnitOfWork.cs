using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Data;
using SAX.CoreLibrary.Domains.Interfaces;
using SAX.CoreLibrary.Domains.Models;
using SAX.CoreLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace SAX.CoreLibrary.UnitOfWork
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

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

        public abstract void Dispose();

        public bool Hack()
        {
            return true;
        }
    }
}
