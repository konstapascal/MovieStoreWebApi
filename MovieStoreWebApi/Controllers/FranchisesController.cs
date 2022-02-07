using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Franchise;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/franchises")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseRepository _repository;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            var franchise = await _repository.GetSpecificFranchiseAsync(id);
            var dtoFranchise = _mapper.Map<FranchiseReadDTO>(franchise);

            return dtoFranchise;
        }

        [HttpGet]
        public async Task<IEnumerable<FranchiseReadDTO>> GetAllFranchises()
        {
            var franchises = await _repository.GetAllFranchisesAsync();
            var dtoFranchises = _mapper.Map<List<FranchiseReadDTO>>(franchises);

            return dtoFranchises;
        }
        
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<FranchiseMovieDTO>>> GetFranchiseMovies(int id)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            var franchiseMovies = await _repository.GetAllMoviesInFranchise(id);
            var dtoFranchiseMovies = _mapper.Map<List<FranchiseMovieDTO>>(franchiseMovies);

            return dtoFranchiseMovies;
        }

        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<FranchiseCharacterDTO>>> GetFranchiseCharacters(int id)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            var franchiseCharacters = await _repository.GetAllCharactersInFranchise(id);
            var dtoFranchiseCharacters = _mapper.Map<List<FranchiseCharacterDTO>>(franchiseCharacters);

            return dtoFranchiseCharacters;
        }

        [HttpPost]
        public async Task<ActionResult<Franchise>> AddFranchise(FranchiseCreateDTO dtoFranchise)
        {
            var domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            domainFranchise = await _repository.AddFranchiseAsync(domainFranchise);

            return CreatedAtAction("GetFranchise",
                new { id = domainFranchise.Id },
                _mapper.Map<FranchiseReadDTO>(domainFranchise));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            await _repository.DeleteFranchiseAsync(id);

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFranchise(int id, FranchiseUpdateDTO dtoFranchise)
        {
            if (id != dtoFranchise.Id)
                return BadRequest();

            if (!_repository.FranchiseExists(id))
                return NotFound();

            Franchise domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            await _repository.UpdateFranchiseAsync(domainFranchise);

            return NoContent();
        }

        [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateFranchiseMovies(int id,  int[] movieIds)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            await _repository.UpdateMoviesInFranchise(id, movieIds);

            return NoContent();
        }
    }
}
