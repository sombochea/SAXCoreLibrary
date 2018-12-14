using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Models;

namespace SAX.CoreLibrary.Repositories
{
    public class RemRepository : Repository<OpenClass>, IRemRepository
    {
        public RemRepository(DbContext context) : base(context)
        {
        }
    }
}
