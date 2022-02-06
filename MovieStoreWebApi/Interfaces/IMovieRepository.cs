using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Interfaces
{
	public interface IMovieRepository
	{
		// Basic CRUD functionality
		public Task<Movie> GetSpecificMovieAsync(int id);
		public Task<IEnumerable<Movie>> GetAllMoviesAsync();
		public Task<Movie> AddMovieAsync(Movie movie);
		public Task UpdateMovieAsync(Movie movie);
		public Task DeleteMovieAsync(int id);

		// Additional functionality
		public Task UpdateCharactersInMovie(int id, int[] characterIds);
		public Task<List<Character>> GetAllCharactersInMovie(int id);

		// Utility functionality
		public bool MovieExists(int id);
	}
}
