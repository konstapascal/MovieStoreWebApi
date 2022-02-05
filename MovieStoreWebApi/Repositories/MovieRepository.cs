using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;

namespace MovieStoreWebApi.Repositories
{
	public class MovieRepository : GenericRepository<Movie>, IMovieRepository
	{
		public MovieRepository(MovieStoreDbContext context) : base(context)
		{
		}
	}
}
