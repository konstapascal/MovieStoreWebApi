using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Repositories
{
	public class FranchiseRepository : IFranchiseRepository
	{
		private readonly MovieStoreDbContext _context;

		public FranchiseRepository(MovieStoreDbContext context)
		{
			_context = context;
		}

		public bool FranchiseExists(int id)
		{
			return _context.Franchises
				.Any(franchise => franchise.Id == id);
		}

		public async Task<Franchise> CreateFranchiseAsync(Franchise franchise)
		{
			_context.Franchises.Add(franchise);
			await _context.SaveChangesAsync();

			return franchise;
		}

		public async Task DeleteFranchiseAsync(int id)
		{

			var franchise = await _context.Franchises.FindAsync(id);
			var moviesWithFranchiseId = _context.Movies.Where(movie => movie.FranchiseId == id);

			foreach (var movie in moviesWithFranchiseId)
				movie.FranchiseId = null;

			_context.Franchises.Remove(franchise);

			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Franchise>> ReadAllFranchisesAsync()
		{
			return await _context.Franchises
				.Include(franchise => franchise.Movies)
				.ToListAsync();
		}

		public async Task<Franchise> ReadSpecificFranchiseAsync(int id)
		{
			return await _context.Franchises
				.Include(franchise => franchise.Movies)
				.FirstOrDefaultAsync(franchise => franchise.Id == id);
		}
		 
		public async Task UpdateFranchiseAsync(Franchise franchise)
		{
			_context.Entry(franchise).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
