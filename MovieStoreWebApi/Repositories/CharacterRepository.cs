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

		/// <summary>
		/// Checks to see if specific character exists
		/// </summary>
		/// <param name="id">The id of the character</param>
		/// <returns>Returns true or false</returns>
		public bool CharacterExists(int id)
		{
			return _context.Characters
				.Any(character => character.Id == id);
		}

		/// <summary>
		/// Get character with specified id from the table
		/// </summary>
		/// <param name="id">The id of the character to be retrieved</param>
		/// <returns>Returns the character</returns>
		public async Task<Character> GetSpecificCharacterAsync(int id)
		{
			return await _context.Characters
				.Include(character => character.Movies)
				.FirstOrDefaultAsync(character => character.Id == id);
		}
		
		/// <summary>
		/// Get all characters from the table
		/// </summary>
		/// <returns>Returns an IEnumerable list of all characters</returns>
		public async Task<IEnumerable<Character>> GetAllCharactersAsync()
		{
			return await _context.Characters
				.Include(character => character.Movies)
				.ToListAsync();
		}
		
		/// <summary>
		/// Add the provided character to the table
		/// </summary>
		/// <param name="character">The character to be added</param>
		/// <returns>Returns the character that was added</returns>
		public async Task<Character> AddCharacterAsync(Character character)
		{
			// Adds character and save changes
			_context.Characters.Add(character);
			await _context.SaveChangesAsync();
			
			return character;
		}

		/// <summary>
		/// Remove the provided character from the database
		/// </summary>
		/// <param name="id">The id of the character to be deleted</param>
		/// <returns></returns>
		public async Task DeleteCharacterAsync(int id)
		{
			// Find the character
			var character = await _context.Characters.FindAsync(id);
		
			// Remove the found character and save changes
			_context.Characters.Remove(character);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates the fields of the specified character
		/// </summary>
		/// <param name="character">The character to be modified</param>
		/// <returns></returns>
		public async Task UpdateCharacterAsync(Character character)
		{
			// Updates character and saves changes
			_context.Entry(character).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
