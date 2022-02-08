using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Character;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/characters")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _repository;
        private readonly IMapper _mapper;

        public CharactersController(ICharacterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get character with the specified id from the table
        /// </summary>
        /// <param name="id">The id of the character to be retrieved</param>
        /// <returns>Returns the character</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            if (!_repository.CharacterExists(id))
                return NotFound();

            var character = await _repository.GetSpecificCharacterAsync(id);
            var dtoCharacter = _mapper.Map<CharacterReadDTO>(character);
            
            return dtoCharacter;
        }

        /// <summary>
        /// Get all characters from the table
        /// </summary>
        /// <returns>Returns an IEnumerable List of all characters</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<CharacterReadDTO>> GetAllCharacters()
        {
            var characters = await _repository.GetAllCharactersAsync();
            var dtoCharacters = _mapper.Map<List<CharacterReadDTO>>(characters); 
            
            return dtoCharacters;
        }
        
        /// <summary>
        /// Add the provided character to the table
        /// </summary>
        /// <param name="dtoCharacter">The character to be added</param>
        /// <returns>Returns the character that was added</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreateDTO dtoCharacter)
        {
            var domainCharacter = _mapper.Map<Character>(dtoCharacter);
            domainCharacter = await _repository.AddCharacterAsync(domainCharacter);

            return CreatedAtAction("PostCharacter",
                new { id = domainCharacter.Id },
                _mapper.Map<CharacterReadDTO>(domainCharacter));
        }

        /// <summary>
        /// Delete a specific character with id from the table
        /// </summary>
        /// <param name="id">The id of the specific character</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (!_repository.CharacterExists(id))
                return NotFound();

            await _repository.DeleteCharacterAsync(id);

            return NoContent();

        }

        /// <summary>
        /// Updates the fields of the specified character
        /// </summary>
        /// <param name="id">The id of the character to be updated</param>
        /// <param name="dtoCharacter">The new values of the character</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCharacter(int id, CharacterUpdateDTO dtoCharacter)
        {
            if (id != dtoCharacter.Id)
                return BadRequest();

            if (!_repository.CharacterExists(id))
                return NotFound();

            Character domainCharacter = _mapper.Map<Character>(dtoCharacter);
            await _repository.UpdateCharacterAsync(domainCharacter);

            return NoContent();
        }
    }
}
