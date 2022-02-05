using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Interfaces
{
	public interface IMovieRepository
	{
		public Task<Movie> ReadSpecificMovieAsync(int id);
		public Task<IEnumerable<Movie>> ReadAllMoviesAsync();
		public Task<Movie> CreateMovieAsync(Movie movie);
		public Task UpdateMovieAsync(Movie movie);
		public Task DeleteMovieAsync(int id);
		public bool MovieExists(int id);
	}
}
