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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<CharacterReadDTO>> GetAllCharacters()
        {
            var characters = await _repository.GetAllCharactersAsync();
            var dtoCharacters = _mapper.Map<List<CharacterReadDTO>>(characters); 
            
            return dtoCharacters;
        }
        
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoCharacter"></param>
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
