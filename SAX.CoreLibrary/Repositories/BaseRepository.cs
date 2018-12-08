using Microsoft.EntityFrameworkCore;
using SAX.CoreLibrary.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAX.CoreLibrary.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        internal readonly DbSet<TEntity> entities;
        protected BaseRepository(DbContext context)
        {
            Context = context;
            entities = Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities;
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return entities.Where(predicate);
        }

        public TEntity GetById(object id)
        {
            return entities.Find(id);
        }

        public int Count(Func<TEntity, bool> predicate)
        {
            return entities.Count(predicate);
        }

        public int Count()
        {
            return entities.Count();
        }

        public long LongCount()
        {
            return entities.LongCount();
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
            return entities.Local.Any(e => e == entity);
        }

        public bool Exists(TEntity entity)
        {
            return IsAttached(entity);
        }
    }
}
