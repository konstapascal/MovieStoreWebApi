using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Interfaces
{
	public interface IFranchiseRepository
	{
		// Basic CRUD functionality
		public Task<Franchise> GetSpecificFranchiseAsync(int id);
		public Task<IEnumerable<Franchise>> GetAllFranchisesAsync();
		public Task<Franchise> AddFranchiseAsync(Franchise franchise);
		public Task UpdateFranchiseAsync(Franchise franchise);
		public Task DeleteFranchiseAsync(int id);

		// Additional functionality
		public Task<IEnumerable<Movie>> GetAllMoviesInFranchise(int id);
		public Task<IEnumerable<Character>> GetAllCharactersInFranchise(int id);
		public Task UpdateMoviesInFranchise(int id, int[] movieIds);

		// Utility functionality
		public bool FranchiseExists(int id);
	}
}
