using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SAX.CoreLibrary.Repositories
{
    public class Repository<TEntity> : BaseRepository<TEntity> where TEntity : class
    {
        public Repository(DbContext context) : base(context)
        {
        }

        public override void Add(TEntity entity, out bool added) => added = Context.Add(entity) == null ? false : Save() > 0;

        public override void Update(TEntity entity, out bool updated) => updated = Context.Update(entity) == null ? false : Save() > 0;

        public override void Delete(TEntity entity, out bool deleted) => deleted = Context.Remove(entity) == null ? false : Save() > 0;

        public override IEnumerable<TEntity> GetEntities() => GetAll();

        public override TEntity GetEntity(object id) => GetById(id);

        public override int CreateAndSaved(TEntity entity)
        {
            Create(entity);
            return Save();
        }

        public override int ModifyAndSaved(TEntity entity)
        {
            Modify(entity);
            return Save();
        }

        public override int RemoveAndSaved(TEntity entity)
        {
            Remove(entity);
            return Save();
        }

        public override int AddAndSaved(TEntity entity)
        {
            Add(entity);
            return Save();
        }

        public override int UpdateAndSaved(TEntity entity)
        {
            Update(entity);
            return Save();
        }

        public override int DeleteAndSaved(TEntity entity)
        {
            Delete(entity);
            return Save();
        }

        public override int CreateAndSaved(IList<TEntity> entities)
        {
            Create(entities);
            return Save();
        }

        public override int ModifyAndSaved(IList<TEntity> entities)
        {
            Modify(entities);
            return Save();
        }

        public override int RemoveAndSaved(IList<TEntity> entities)
        {
            Remove(entities);
            return Save();
        }

        public override int AddAndSaved(IList<TEntity> entities)
        {
            Add(entities);
            return Save();
        }

        public override int UpdateAndSaved(IList<TEntity> entities)
        {
            Update(entities);
            return Save();
        }

        public override int DeleteAndSaved(IList<TEntity> entities)
        {
            Delete(entities);
            return Save();
        }

        public override bool Deletable() => Context.Entry(Entity).State == EntityState.Detached;

        public override bool Deletable(TEntity entity) => Context.Entry(entity).State == EntityState.Detached;

        public override void ForeDelete(TEntity entity)
        {
            if (Deletable(entity))
            {
                Attached(entity);
                Delete(entity);
            }
        }
        
        public override void ForeDelete(TEntity entity, out bool deleted)
        {
            deleted = false;
            if (Deletable(entity))
            {
                Attached(entity);
                Delete(entity, out deleted);
            }
        }

        public override bool IsExists(object primaryKey)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsExists(string pearValue)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsDeleted(object primaryKey)
        {
            throw new System.NotImplementedException();
        }
    }
}