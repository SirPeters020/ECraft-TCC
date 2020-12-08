using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecraft.Api.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly ECraftContext Context;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(ECraftContext context)
        {
            this.Context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual async Task<bool> DeleteAsync(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            if (entityToDelete == null)
            {
                return false;
            }
            Delete(entityToDelete);
            return true;
        }

        public virtual void Delete(IEnumerable<TEntity> entitiesToDelete)
        {
            foreach (var e in entitiesToDelete)
            {
                Delete(e);
            }
        }


        //async Task<ActionResult<IEnumerable<AAI>>>
        public virtual async Task<IList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool asNoTrack = false)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = asNoTrack ? query.AsNoTracking().Where(filter) : query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual IList<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", bool asNoTrack = false)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = asNoTrack ? query.AsNoTracking().Where(filter) : query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }


        public virtual async Task<TEntity> GetByIdAssync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(Convert.ToInt32(id));
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var e in entities)
            {
                dbSet.Add(e);
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {

            dbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Update(IEnumerable<TEntity> entitiesToUpdate)
        {
            foreach (var e in entitiesToUpdate)
            {
                dbSet.Attach(e);
                Context.Entry(e).State = EntityState.Modified;
            }

        }


        public bool EntityExists(object id)
        {
            return (dbSet.Find(id) != null);
        }

    }
}
