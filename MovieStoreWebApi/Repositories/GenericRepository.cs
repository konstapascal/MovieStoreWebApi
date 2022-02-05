using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private readonly MovieStoreDbContext _context;
		
		public GenericRepository(MovieStoreDbContext context)
		{
			_context = context;
		}

		public async Task<TEntity> GetAsync(int id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public async Task DeleteAsync(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
			await _context.SaveChangesAsync();
		}
		
		public Task<TEntity> AddAsync(TEntity entity)
		{
			throw new NotImplementedException();
		}
		
		public Task UpdateAsync(int id, TEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}
