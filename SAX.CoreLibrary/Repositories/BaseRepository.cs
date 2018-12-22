using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAX.CoreLibrary.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        internal readonly DbSet<TEntity> Entity;

        public abstract bool IsDeleted(object primaryKey);

        protected BaseRepository(DbContext context)
        {
            Context = context;
            Entity = Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entity;
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return Entity.Where(predicate);
        }

        public TEntity GetById(object id)
        {
            return Entity.Find(id);
        }

        public int Count(Func<TEntity, bool> predicate)
        {
            return Entity.Count(predicate);
        }

        public int Count()
        {
            return Entity.Count();
        }

        public long LongCount()
        {
            return Entity.LongCount();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }

        public void Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public void Add(IList<TEntity> entities)
        {
            Context.AddRange(entities);
        }

        public void Create(TEntity entity)
        {
            Context.Add(entity);
        }

        public void Create(IList<TEntity> entities)
        {
            Add(entities);
        }

        public abstract void Add(TEntity entity, out bool added);

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IList<TEntity> entities)
        {
            Context.UpdateRange(entities);
        }

        public void Modify(TEntity entity)
        {
            Context.Update(entity);
        }

        public void Modify(IList<TEntity> entities)
        {
            Update(entities);
        }

        public abstract void Update(TEntity entity, out bool updated);

        public void Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(IList<TEntity> entities)
        {
            Context.RemoveRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Remove(entity);
        }

        public void Remove(IList<TEntity> entities)
        {
            Delete(entities);
        }

        public abstract void Delete(TEntity entity, out bool deleted);

        public void Detached(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }

        public void Detached(IList<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                Context.Entry(entity).State = EntityState.Detached;
        }

        public void Unchanged(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Unchanged;
        }

        public void DoTransaction()
        {
            Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            Context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            Context.Database.RollbackTransaction();
        }

        public void Attached(TEntity entity)
        {
            Context.Attach(entity);
        }

        public void Attached(IList<TEntity> entities)
        {
            Context.AttachRange(entities);
        }

        public bool IsDetached(TEntity entity)
        {
            return Context.Entry(entity).State == EntityState.Detached;
        }

        public bool IsAttached(TEntity entity)
        {
            return Entity.Local.Any(e => e == entity);
        }

        public bool Exists(TEntity entity)
        {
            return IsAttached(entity);
        }

        public abstract IEnumerable<TEntity> GetEntities();
        public abstract TEntity GetEntity(object id);
        public abstract int CreateAndSaved(TEntity entity);
        public abstract int CreateAndSaved(IList<TEntity> entities);
        public abstract int ModifyAndSaved(TEntity entity);
        public abstract int ModifyAndSaved(IList<TEntity> entities);
        public abstract int RemoveAndSaved(TEntity entity);
        public abstract int RemoveAndSaved(IList<TEntity> entities);
        public abstract int AddAndSaved(TEntity entity);
        public abstract int AddAndSaved(IList<TEntity> entities);
        public abstract int UpdateAndSaved(TEntity entity);
        public abstract int UpdateAndSaved(IList<TEntity> entities);
        public abstract int DeleteAndSaved(TEntity entity);
        public abstract int DeleteAndSaved(IList<TEntity> entities);
        public abstract bool Deletable();
        public abstract bool Deletable(TEntity entity);
        public abstract void ForeDelete(TEntity entity);
        public abstract void ForeDelete(TEntity entity, out bool deleted);
        public abstract bool IsExists(object primaryKey);
        public abstract bool IsExists(string pearValue);

        public virtual bool IsExists(TEntity entity)
        {
            return Entity.Any(t => t == entity);
        }

        public virtual int Restore()
        {
            var deletedEntities = Entity.IgnoreQueryFilters().Where(entity => EF.Property<bool>(entity, "IsDeleted") == true);
            foreach (var deletedEntity in deletedEntities)
            {
                var entity = Context.ChangeTracker.Entries<TEntity>().First(entry => entry.Entity == deletedEntity);
                entity.Property("IsDeleted").CurrentValue = false;
            }
            return Save();
        }

        public IList<TEntity> GetDeleted()
        {
            return Entity.IgnoreQueryFilters()
                .Where(entity => EF.Property<bool>(entity, "IsDeleted") == true)
                .ToList();
        }
        
    }
}
