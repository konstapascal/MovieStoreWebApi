using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Interfaces
{
	public interface IFranchiseRepository
	{
		public Task<Franchise> ReadSpecificFranchiseAsync(int id);
		public Task<IEnumerable<Franchise>> ReadAllFranchisesAsync();
		public Task<Franchise> CreateFranchiseAsync(Franchise franchise);
		public Task UpdateFranchiseAsync(Franchise franchise);
		public Task DeleteFranchiseAsync(int id);
		public bool FranchiseExists(int id);
	}
}
