using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;

namespace MovieStoreWebApi.Repositories
{
	public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
	{
		public CharacterRepository(MovieStoreDbContext context) : base(context)
		{
		}
	}
}
