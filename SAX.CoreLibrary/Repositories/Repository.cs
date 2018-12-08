using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAX.CoreLibrary.Repositories
{
    public class Repository<TEntity> : BaseRepository<TEntity>, ICRUDRepository<TEntity>, ISoftDeletable where TEntity : class
    {
        public Repository(DbContext context) : base(context)
        {
        }

        public override void Add(TEntity entity, out bool added)
        {
            var ent = Context.Add(entity);
            if (ent == null)
            {
                added = false;
                return;
            }

            Save();
            added = true;
        }

        public override void Update(TEntity entity, out bool updated)
        {
            var ent = Context.Update(entity);
            if (ent == null)
            {
                updated = false;
                return;
            }

            Save();
            updated = true;
        }

        public override void Delete(TEntity entity, out bool deleted)
        {
            var ent = Context.Remove(entity);
            if (ent == null)
            {
                deleted = false;
                return;
            }

            Save();
            deleted = true;

        }

        public IEnumerable<TEntity> GetEntities()
        {
            return GetAll();
        }

        public TEntity GetEntity(object id)
        {
            return GetById(id);
        }

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

        public bool IsDeleted()
        {
            return false;
        }

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
    }
}