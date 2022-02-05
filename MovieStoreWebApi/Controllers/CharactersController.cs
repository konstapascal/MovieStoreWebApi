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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            var character = await _repository.ReadSpecificCharacterAsync(id);

            if (character == null)
                return NotFound();
            
            var dtoCharacter = _mapper.Map<CharacterReadDTO>(character);
            
            return dtoCharacter;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IEnumerable<CharacterReadDTO>> GetCharacters()
        {
            var characters = await _repository.ReadAllCharactersAsync();
            var dtoCharacters = _mapper.Map<List<CharacterReadDTO>>(characters); 
            
            return dtoCharacters;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (!_repository.CharacterExists(id))
                return NotFound();

            await _repository.DeleteCharacterAsync(id);

            return NoContent();

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreateDTO dtoCharacter)
        {
            var domainCharacter = _mapper.Map<Character>(dtoCharacter);

            domainCharacter = await _repository.CreateCharacterAsync(domainCharacter);

            return CreatedAtAction("GetCharacter",
                new { id = domainCharacter.Id },
                _mapper.Map<CharacterReadDTO>(domainCharacter));
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterUpdateDTO dtoCharacter)
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
