using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Interfaces
{
	public interface ICharacterRepository
	{
		public Task<Character> ReadSpecificCharacterAsync(int id);
		public Task<IEnumerable<Character>> ReadAllCharactersAsync();
		public Task<Character> CreateCharacterAsync(Character character);
		public Task UpdateCharacterAsync(Character character);
		public Task DeleteCharacterAsync(int id);
		public bool CharacterExists(int id);
	}
}
