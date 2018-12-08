using System;
using System.Collections.Generic;
using System.Text;

namespace SAX.CoreLibrary.Domains.Interfaces
{
    public interface ISoftDeletable<TEntity> where TEntity : class
    {
        bool IsDeleted { get; }

        bool Deletable();
        bool Deletable(TEntity entity);
        void ForeDelete(TEntity entity);
        void ForeDelete(TEntity entity, out bool deleted);
    }
}
