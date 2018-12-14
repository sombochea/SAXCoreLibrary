using System;
using System.Collections.Generic;
using System.Text;

namespace SAX.CoreLibrary.Domains.Interfaces
{
    public interface IPearEntityRepository<TEntity, ID> where TEntity : class
    {
        bool IsExists(TEntity entity);

    }
}
