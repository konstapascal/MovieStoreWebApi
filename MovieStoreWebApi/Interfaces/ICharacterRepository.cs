using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Interfaces
{
	public interface ICharacterRepository
	{
		// Basic CRUD functionality
		public Task<Character> GetSpecificCharacterAsync(int id);
		public Task<IEnumerable<Character>> GetAllCharactersAsync();
		public Task<Character> AddCharacterAsync(Character character);
		public Task UpdateCharacterAsync(Character character);
		public Task DeleteCharacterAsync(int id);

		// Utility functionality
		public bool CharacterExists(int id);
	}
}
