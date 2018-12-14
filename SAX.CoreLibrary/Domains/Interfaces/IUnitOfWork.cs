using System;
using System.Threading.Tasks;

namespace SAX.CoreLibrary.Domains.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        Task<int> CompleteAsync();
    }
}
