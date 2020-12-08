using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ecraft.Api.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        Task<IList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", bool asNoTrack = false
            );
        Task<TEntity> GetByIdAssync(object id);

        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entityToUpdate);
        void Update(IEnumerable<TEntity> entitiesToUpdate);

        void Delete(TEntity entityToDelete);
        void Delete(IEnumerable<TEntity> entitiesToDelete);

        Task<bool> DeleteAsync(object id);

        public bool EntityExists(object id);
    }
}
