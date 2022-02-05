using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Interfaces
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
        public Task<TEntity> GetAsync(int id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> AddAsync(TEntity entity);
        public Task UpdateAsync(int id, TEntity entity);
        public Task DeleteAsync(TEntity entity);
    }
}
