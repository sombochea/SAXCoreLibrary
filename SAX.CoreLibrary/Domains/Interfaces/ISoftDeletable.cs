
using System.Collections.Generic;

namespace SAX.CoreLibrary.Domains.Interfaces
{
    public interface ISoftDeletable<TEntity> where TEntity : class
    {
        bool IsDeleted(object primaryKey);
        bool Deletable();
        int Restore();
        bool Deletable(TEntity entity);
        void ForeDelete(TEntity entity);
        void ForeDelete(TEntity entity, out bool deleted);
        IList<TEntity> GetDeleted();
    }
}
