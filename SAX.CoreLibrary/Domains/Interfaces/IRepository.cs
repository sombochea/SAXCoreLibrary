using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAX.CoreLibrary.Domains.Interfaces
{
    public interface IRepository<TEntity> : ICRUDRepository<TEntity>, IPearEntityRepository<TEntity>, ISoftDeletable<TEntity> where TEntity : class
    {
        #region Get Entity

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        TEntity GetById(object id);

        #endregion

        #region Count Data in Entity

        int Count(Func<TEntity, bool> predicate);
        int Count();
        long LongCount();

        #endregion

        #region Save Data

        int Save();
        Task<int> SaveAsync();

        #endregion

        #region Add or Create Entity

        void Add(TEntity entity);
        void Add(IList<TEntity> entities);
        void Create(TEntity entity);
        void Create(IList<TEntity> entities);

        #endregion

        #region Update or Modify Entity

        void Update(TEntity entity);
        void Update(IList<TEntity> entities);
        void Modify(TEntity entity);
        void Modify(IList<TEntity> entities);

        #endregion

        #region Delete or Remove Entity

        void Delete(TEntity entity);
        void Delete(IList<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(IList<TEntity> entities);

        #endregion

        #region Entity State

        void Detached(TEntity entity);
        bool IsDetached(TEntity entity);
        void Detached(IList<TEntity> entity);
        void Unchanged(TEntity entity);

        #endregion

        #region Entity Attached

        void Attached(TEntity entity);
        bool IsAttached(TEntity entity);
        void Attached(IList<TEntity> entity);

        #endregion

        #region DB Transactions

        void DoTransaction();
        void RollBack();
        void Commit();

        #endregion
    }
}
