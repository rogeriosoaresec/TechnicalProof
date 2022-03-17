using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LandingApi.DataAccess.Context;
using LandingApi.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LandingApi.DataAccess.Repositories
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private CampaignContext _campaignContext;

        public Repository(CampaignContext userCampaignContext)
        {
            _campaignContext = userCampaignContext ?? throw new ArgumentNullException(nameof(userCampaignContext));
        }
		public async Task<TEntity> AddAsync(TEntity obj)
        {
            _campaignContext.Set<TEntity>();
            await _campaignContext.AddAsync(obj);
            await _campaignContext.SaveChangesAsync();

            return obj;
        }

        public async Task DeleteAsync(TEntity obj)
        {
            _campaignContext.Remove(obj);
            await _campaignContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_campaignContext != null)
            {
                _campaignContext.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> Get()
        {
            return _campaignContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate, Expression<Func<TEntity, object>> includes)
        {
            return Get().Include(includes).Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return Get().Where(predicate).AsQueryable();
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            _campaignContext.Set<TEntity>();
            _campaignContext.Update(obj);
            await _campaignContext.SaveChangesAsync();
            return obj;
        }
	}
}