using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models;
using MovieStoreWebApi.Models.Domain;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _repository;

        public CharactersController(ICharacterRepository repository, MovieStoreDbContext context)
        {
            _repository = repository;
        }

        // GET: api/characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            Character character = await _repository.GetAsync(id);

            if (character is null) return NotFound();
            
            return character;
        }
        
        // GET: api/characters
        [HttpGet]
        public async Task<IEnumerable<Character>> GetCharacters()
        {
            IEnumerable<Character> characters = await _repository.GetAllAsync();
            
            return characters;
        }

        // DELETE: api/characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _repository.GetAsync(id);

            if (character == null) return NotFound();

            await _repository.DeleteAsync(character);

            return NoContent();
        }

        // POST: api/characters
        [HttpPost]
        public Task<Character> PostCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        // PUT: api/characters/5
        [HttpPut("{id}")]
        public Task<IActionResult> PutCharacter(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
