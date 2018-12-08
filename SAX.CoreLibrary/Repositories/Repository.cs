using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Domains.Interfaces;
using System.Collections.Generic;

namespace SAX.CoreLibrary.Repositories
{
    public class Repository<TEntity> : BaseRepository<TEntity>, ICRUDRepository<TEntity>, ISoftDeletable<TEntity> where TEntity : class
    {
        public Repository(DbContext context) : base(context)
        {
        }

        public override void Add(TEntity entity, out bool added) => added = Context.Add(entity) == null ? false : Save() > 0;

        public override void Update(TEntity entity, out bool updated) => updated = Context.Update(entity) == null ? false : Save() > 0;

        public override void Delete(TEntity entity, out bool deleted) => deleted = Context.Remove(entity) == null ? false : Save() > 0;

        public IEnumerable<TEntity> GetEntities() => GetAll();

        public TEntity GetEntity(object id) => GetById(id);

        public int CreateAndSaved(TEntity entity)
        {
            Create(entity);
            return Save();
        }

        public int ModifyAndSaved(TEntity entity)
        {
            Modify(entity);
            return Save();
        }

        public int RemoveAndSaved(TEntity entity)
        {
            Remove(entity);
            return Save();
        }

        public int AddAndSaved(TEntity entity)
        {
            Add(entity);
            return Save();
        }

        public int UpdateAndSaved(TEntity entity)
        {
            Update(entity);
            return Save();
        }

        public int DeleteAndSaved(TEntity entity)
        {
            Delete(entity);
            return Save();
        }

        public bool IsDeleted => false;

        public int CreateAndSaved(IList<TEntity> entities)
        {
            Create(entities);
            return Save();
        }

        public int ModifyAndSaved(IList<TEntity> entities)
        {
            Modify(entities);
            return Save();
        }

        public int RemoveAndSaved(IList<TEntity> entities)
        {
            Remove(entities);
            return Save();
        }

        public int AddAndSaved(IList<TEntity> entities)
        {
            Add(entities);
            return Save();
        }

        public int UpdateAndSaved(IList<TEntity> entities)
        {
            Update(entities);
            return Save();
        }

        public int DeleteAndSaved(IList<TEntity> entities)
        {
            Delete(entities);
            return Save();
        }

        public bool Deletable() => Context.Entry(entities).State == EntityState.Detached;

        public bool Deletable(TEntity entity) => Context.Entry(entity).State == EntityState.Detached;

        public void ForeDelete(TEntity entity)
        {
            if (Deletable(entity))
            {
                Attached(entity);
                Delete(entity);
            }
        }
        
        public void ForeDelete(TEntity entity, out bool deleted)
        {
            deleted = false;
            if (Deletable(entity))
            {
                Attached(entity);
                Delete(entity, out deleted);
            }
        }

    }
}