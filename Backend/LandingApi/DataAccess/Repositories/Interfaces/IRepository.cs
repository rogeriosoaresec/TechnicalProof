using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LandingApi.DataAccess.Repositories.Interfaces
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate, Expression<Func<TEntity, object>> includes);
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task DeleteAsync(TEntity obj);
	}
}