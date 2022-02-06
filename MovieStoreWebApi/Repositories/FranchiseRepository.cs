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

		/// <summary>
		/// Get franchise with specified id from the table
		/// </summary>
		/// <param name="id">The id of the franchise to be retrieved</param>
		/// <returns>Returns the franchise</returns>
		public async Task<Franchise> GetSpecificFranchiseAsync(int id)
		{
			return await _context.Franchises
				.Include(franchise => franchise.Movies)
				.FirstOrDefaultAsync(franchise => franchise.Id == id);
		}
		
		/// <summary>
		/// Get all franchises from the table
		/// </summary>
		/// <returns>Returns an IEnumerable list of the franchises</returns>
		public async Task<IEnumerable<Franchise>> GetAllFranchisesAsync()
		{
			return await _context.Franchises
				.Include(franchise => franchise.Movies)
				.ToListAsync();
		}
		
		/// <summary>
		/// Get all characters from a franchise
		/// </summary>
		/// <param name="id">The id of the franchise to get the characters from</param>
		/// <returns>Returns and IEnumerable list of all characters</returns>
		public async Task<IEnumerable<Character>> GetAllCharactersInFranchise(int id)
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
		
		/// <summary>
		/// Get all movies from a franchise
		/// </summary>
		/// <param name="id">The id of the franchise to get the movies from</param>
		/// <returns>Returns an IEnumerable list of all movies</returns>
		public async Task<IEnumerable<Movie>> GetAllMoviesInFranchise(int id)
		{
			var franchise = await _context.Franchises
				.Include(franchise => franchise.Movies)
				.FirstOrDefaultAsync(franchise => franchise.Id == id);

			var franchiseMovies = new List<Movie>();

			foreach (var movie in franchise.Movies)
				franchiseMovies.Add(movie);

			return franchiseMovies;
		}

		/// <summary>
		/// Add a franchise to the table
		/// </summary>
		/// <param name="franchise">The franchise to be added</param>
		/// <returns>Returns the franchise that was added</returns>
		public async Task<Franchise> AddFranchiseAsync(Franchise franchise)
		{
			_context.Franchises.Add(franchise);
			await _context.SaveChangesAsync();

			return franchise;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
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
		 
		public async Task UpdateFranchiseAsync(Franchise franchise)
		{
			_context.Entry(franchise).State = EntityState.Modified;
			await _context.SaveChangesAsync();
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
		
		public bool FranchiseExists(int id)
		{
			return _context.Franchises
				.Any(franchise => franchise.Id == id);
		}
	}
}
