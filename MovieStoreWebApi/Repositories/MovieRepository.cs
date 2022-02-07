using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Repositories
{
	public class MovieRepository : IMovieRepository
	{
		private readonly MovieStoreDbContext _context;

		public MovieRepository(MovieStoreDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Checks to see if specific movie exists
		/// </summary>
		/// <param name="id">The id of the movie</param>
		/// <returns>Returns true or false</returns>
		public bool MovieExists(int id)
		{
			return _context.Movies
				.Any(movie => movie.Id == id);
		}

		/// <summary>
		/// Get movie with specified id from the table
		/// </summary>
		/// <param name="id">The id of the movie to be retrieved</param>
		/// <returns>Returns the movie</returns>
		public async Task<Movie> GetSpecificMovieAsync(int id)
		{
			return await _context.Movies
				.Include(movie => movie.Characters)
				.FirstOrDefaultAsync(movie => movie.Id == id);
		}

		/// <summary>
		/// Get all movies from the table
		/// </summary>
		/// <returns>Returns an IEnumerable list of all movies</returns>
		public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
		{
			return await _context.Movies
				.Include(movie => movie.Characters)
				.ToListAsync();
		}

		/// <summary>
		/// Get all characters from a movie
		/// </summary>
		/// <param name="id">The id of the movie to get the characters of</param>
		/// <returns>Returns and IEnumerable list of characters</returns>
		public async Task<IEnumerable<Character>> GetAllCharactersInMovie(int id)
		{
			var movie = await _context.Movies
				.Include(movie => movie.Characters)
				.FirstOrDefaultAsync(movie => movie.Id == id);

			var movieCharacters = new List<Character>();

			foreach (var character in movie.Characters)
				movieCharacters.Add(character);

			return movieCharacters;
		}

		/// <summary>
		/// Add the provided movie to the table
		/// </summary>
		/// <param name="movie">The movie to be added</param>
		/// <returns>Returns the movie that was added</returns>
		public async Task<Movie> AddMovieAsync(Movie movie)
		{
			_context.Movies.Add(movie);
			await _context.SaveChangesAsync();

			return movie;
		}

		/// <summary>
		/// Remove the provided movie from the database
		/// </summary>
		/// <param name="id">The id of the movie to be deleted</param>
		/// <returns></returns>
		public async Task DeleteMovieAsync(int id)
		{
			var movie = await _context.Movies.FindAsync(id);
			_context.Movies.Remove(movie);

			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates the fields of the specified movie
		/// </summary>
		/// <param name="movie">The movie to be modified</param>
		/// <returns></returns>
		public async Task UpdateMovieAsync(Movie movie)
		{
			_context.Entry(movie).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates the characters of a specific movie
		/// </summary>
		/// <param name="id">The id of the movie to change the characters of</param>
		/// <param name="characterIds">The ids of the new characters</param>
		/// <returns></returns>
		public async Task UpdateCharactersInMovie(int id, int[] characterIds)
		{
			// Getting movie with specific id
			var movie = await _context.Movies
				.Include(movie => movie.Characters)
				.FirstOrDefaultAsync(movie => movie.Id == id);

			var newCharacters = new List<Character>();

			// Creating the new list of characters
			foreach (var characterId in characterIds)
			{
				var character = _context.Characters
					.Where(character => character.Id == characterId)
					.FirstOrDefault();
				
				newCharacters.Add(character);
			}

			// Updating the movie with the new characters
			movie.Characters = newCharacters;

			_context.Entry(movie).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
