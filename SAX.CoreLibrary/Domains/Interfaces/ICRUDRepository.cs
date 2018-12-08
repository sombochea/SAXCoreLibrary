using System;
using System.Collections.Generic;
using System.Text;

namespace SAX.CoreLibrary.Domains.Interfaces
{
    public interface ICRUDRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetEntities();
        TEntity GetEntity(object id);

        int CreateAndSaved(TEntity entity);
        int CreateAndSaved(IList<TEntity> entities);

        int ModifyAndSaved(TEntity entity);
        int ModifyAndSaved(IList<TEntity> entities);

        int RemoveAndSaved(TEntity entity);
        int RemoveAndSaved(IList<TEntity> entities);

        int AddAndSaved(TEntity entity);
        int AddAndSaved(IList<TEntity> entities);

        int UpdateAndSaved(TEntity entity);
        int UpdateAndSaved(IList<TEntity> entities);

        int DeleteAndSaved(TEntity entity);
        int DeleteAndSaved(IList<TEntity> entities);
    }
}
