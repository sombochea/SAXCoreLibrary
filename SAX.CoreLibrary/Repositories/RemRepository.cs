using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Domains.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAX.CoreLibrary.Repositories
{
    public class RemRepository : Repository<OpenClass>
    {
        public RemRepository(DbContext context) : base(context)
        {
        }
    }
}
