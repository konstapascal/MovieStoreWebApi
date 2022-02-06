using Microsoft.AspNetCore.Mvc;
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

		public async Task<Franchise> AddFranchiseAsync(Franchise franchise)
		{
			_context.Franchises.Add(franchise);
			await _context.SaveChangesAsync();

			return franchise;
		}

		public async Task DeleteFranchiseAsync(int id)
		{
			var franchise = await _context.Franchises.FindAsync(id);
			var moviesWithFranchiseId = _context.Movies.Where(movie => movie.FranchiseId == id);

			// Setting FranchiseId of associated movies to null
			foreach (var movie in moviesWithFranchiseId)
				movie.FranchiseId = null;

			// Safely deleting franchise without deleting associated movies
			_context.Franchises.Remove(franchise);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Franchise>> GetAllFranchisesAsync()
		{
			return await _context.Franchises
				.Include(franchise => franchise.Movies)
				.ToListAsync();
		}

		public async Task<Franchise> GetSpecificFranchiseAsync(int id)
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

		public async Task<List<Movie>> GetAllMoviesInFranchise(int id)
		{
			var franchise = await _context.Franchises
				.Include(franchise => franchise.Movies)
				.FirstOrDefaultAsync(franchise => franchise.Id == id);

			var franchiseMovies = new List<Movie>();

			foreach (var movie in franchise.Movies)
				franchiseMovies.Add(movie);

			return franchiseMovies;
		}

		public async Task<List<Character>> GetAllCharactersInFranchise(int id)
		{
			// Get the franchise with the specific id
			var franchise = await _context.Franchises
				.Include(franchise => franchise.Movies)
				.ThenInclude(movie => movie.Characters)
				.FirstOrDefaultAsync(franchise => franchise.Id == id);
			
			var franchiseCharacters = new List<Character>();

			// Iterate over every movie in the franchise
			foreach (var movie in franchise.Movies)
			{
				// Iterate over every character in the movie, add it to list
				foreach (var character in movie.Characters)
					franchiseCharacters.Add(character);
			}

			// Return list of characters included in franchise
			return franchiseCharacters;
		}
		
		public async Task UpdateMoviesInFranchise(int id, int[] movieIds)
		{
			var franchise = await _context.Franchises
				.Include(franchise => franchise.Movies)
				.FirstOrDefaultAsync(franchise => franchise.Id == id);

			var newMovies = new List<Movie>();

			// Creating the new list of movies
			foreach (var movieId in movieIds)
			{
				var movie = _context.Movies.Where(movie => movie.Id == movieId).FirstOrDefault();
				newMovies.Add(movie);
			}

			// Updating the franchise with the new movies
			franchise.Movies = newMovies;

			_context.Entry(franchise).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
