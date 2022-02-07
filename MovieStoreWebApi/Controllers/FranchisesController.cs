using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Franchise;
using MovieStoreWebApi.Repositories;

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

        public FranchisesController(FranchiseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            var franchise = await _repository.GetSpecificFranchiseAsync(id);
            var dtoFranchise = _mapper.Map<FranchiseReadDTO>(franchise);

            return dtoFranchise;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<FranchiseReadDTO>> GetAllFranchises()
        {
            var franchises = await _repository.GetAllFranchisesAsync();
            var dtoFranchises = _mapper.Map<List<FranchiseReadDTO>>(franchises);

            return dtoFranchises;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/movies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FranchiseMovieDTO>>> GetFranchiseMovies(int id)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            var franchiseMovies = await _repository.GetAllMoviesInFranchise(id);
            var dtoFranchiseMovies = _mapper.Map<List<FranchiseMovieDTO>>(franchiseMovies);

            return dtoFranchiseMovies;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<FranchiseCharacterDTO>>> GetFranchiseCharacters(int id)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            var franchiseCharacters = await _repository.GetAllCharactersInFranchise(id);
            var dtoFranchiseCharacters = _mapper.Map<List<FranchiseCharacterDTO>>(franchiseCharacters);

            return dtoFranchiseCharacters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtoFranchise"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Franchise>> AddFranchise(FranchiseCreateDTO dtoFranchise)
        {
            var domainFranchise = _mapper.Map<Franchise>(dtoFranchise);
            domainFranchise = await _repository.AddFranchiseAsync(domainFranchise);

            return CreatedAtAction("GetFranchise",
                new { id = domainFranchise.Id },
                _mapper.Map<FranchiseReadDTO>(domainFranchise));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            await _repository.DeleteFranchiseAsync(id);

            return NoContent();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoFranchise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movieIds"></param>
        /// <returns></returns>
        [HttpPut("{id}/movies")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateFranchiseMovies(int id,  int[] movieIds)
        {
            if (!_repository.FranchiseExists(id))
                return NotFound();

            await _repository.UpdateMoviesInFranchise(id, movieIds);

            return NoContent();
        }
    }
}
