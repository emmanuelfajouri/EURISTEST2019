using EURIS.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace EURIS.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected IEURISContext Context;
        protected DbSet<T> EntitySet;

        protected RepositoryBase(IEURISContext context)
        {
            Context = context;
            EntitySet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return EntitySet;
        }

        public virtual IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return EntitySet.Where(predicate);
        }

        public virtual void Add(T entity)
        {
            EntitySet.Add(entity);
        }

        protected virtual void DiscartEntityChanges(Object entity)
        {
            var entry = Context.Entry(entity);
            entry.State = EntityState.Unchanged;
        }

        protected virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Attach(entity);
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public virtual void Update(T entity)
        {
            Update<T>(entity);
        }

        public virtual void Remove(T entity)
        {
            EntitySet.Remove(entity);
        }
    }
}
