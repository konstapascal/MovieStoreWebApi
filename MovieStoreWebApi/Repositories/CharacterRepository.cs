using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Repositories
{
	public class CharacterRepository : ICharacterRepository
	{
		private readonly MovieStoreDbContext _context;

		public CharacterRepository(MovieStoreDbContext context)
		{
			_context = context;
		}

		public bool CharacterExists(int id)
		{
			return _context.Characters
				.Any(character => character.Id == id);
		}

		public async Task<Character> AddCharacterAsync(Character character)
		{
			_context.Characters.Add(character);
			await _context.SaveChangesAsync();
			
			return character;
		}

		public async Task DeleteCharacterAsync(int id)
		{
			var character = await _context.Characters.FindAsync(id);
		
			_context.Characters.Remove(character);

			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Character>> GetAllCharactersAsync()
		{
			return await _context.Characters
				.Include(character => character.Movies)
				.ToListAsync();
		}

		public async Task<Character> GetSpecificCharacterAsync(int id)
		{
			return await _context.Characters
				.Include(character => character.Movies)
				.FirstOrDefaultAsync(character => character.Id == id);
		}

		public async Task UpdateCharacterAsync(Character character)
		{
			_context.Entry(character).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
