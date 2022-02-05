using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;

namespace MovieStoreWebApi.Repositories
{
	public class FranchiseRepository : GenericRepository<Franchise>, IFranchiseRepository
	{
		public FranchiseRepository(MovieStoreDbContext context) : base(context)
		{
		}
	}
}
