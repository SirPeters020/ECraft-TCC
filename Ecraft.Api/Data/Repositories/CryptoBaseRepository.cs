using Ecraft.Api.Data.Repositories.Cryptography;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecraft.Api.Data.Repositories
{
    public class CryptoBaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly ECraftContext Context;
        protected DbSet<TEntity> dbSet;
        protected readonly AesCryptographyService _crypto;

        public CryptoBaseRepository(ECraftContext context, AesCryptographyService crypto)
        {
            this.Context = context;
            this.dbSet = context.Set<TEntity>();
            this._crypto = crypto;
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
                return _crypto.Decrypt(await orderBy(query).ToListAsync());
            }
            else
            {
                return _crypto.Decrypt(await query.ToListAsync());
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
                return _crypto.Decrypt(orderBy(query).ToList());
            }
            else
            {
                return _crypto.Decrypt(query.ToList());
            }
        }


        public virtual async Task<TEntity> GetByIdAssync(object id)
        {
            return _crypto.Decrypt(await dbSet.FindAsync(id));
        }

        public virtual TEntity GetById(object id)
        {
            return _crypto.Decrypt(dbSet.Find(Convert.ToInt32(id)));
        }

        public virtual void Insert(TEntity entity)
        {
            var encrypt = _crypto.Encrypt(entity);
            dbSet.Add(encrypt);
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            var encryptList = _crypto.Encrypt(entities);
            foreach (var e in encryptList)
            {
                dbSet.Add(e);
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            var encryptUpdate = _crypto.Encrypt(entityToUpdate);
            dbSet.Attach(encryptUpdate);
            Context.Entry(encryptUpdate).State = EntityState.Modified;
        }

        public virtual void Update(IEnumerable<TEntity> entitiesToUpdate)
        {
            var encryptList = _crypto.Encrypt(entitiesToUpdate);
            foreach (var e in encryptList)
            {
                dbSet.Attach(e);
                Context.Entry(e).State = EntityState.Modified;
            }

        }

        public string EncryptParam(string param)
        {
            return _crypto.Encrypt(param);
        }
        
        public string DecryptParam(string param)
        {
            return _crypto.Decrypt(param);
        }

        public IList<TEntity> GetNoCryptedTable()
        {
            IQueryable<TEntity> query = dbSet;
            return dbSet.ToList();
        }

        public bool EntityExists(object id)
        {
            return (dbSet.Find(id) != null);
        }
    }
}
