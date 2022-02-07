using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Movie;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository repository, IMapper mapper)
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
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            if (!_repository.MovieExists(id))
                return NotFound();

            var movie = await _repository.GetSpecificMovieAsync(id);
            var dtoMovie = _mapper.Map<MovieReadDTO>(movie);

            return dtoMovie;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<MovieReadDTO>> GetAllMovies()
        {
            var movies = await _repository.GetAllMoviesAsync();
            var dtoMovies = _mapper.Map<List<MovieReadDTO>>(movies);

            return dtoMovies;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<MovieCharacterDTO>>> GetMovieCharacters(int id)
		{
            if (!_repository.MovieExists(id))
                return NotFound();

            var movieCharacters = await _repository.GetAllCharactersInMovie(id);
            var dtoMovieCharacters = _mapper.Map<List<MovieCharacterDTO>>(movieCharacters);

            return dtoMovieCharacters;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtoMovie"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(MovieCreateDTO dtoMovie)
        {
            var domainMovie = _mapper.Map<Movie>(dtoMovie);
            domainMovie = await _repository.AddMovieAsync(domainMovie);

            return CreatedAtAction("GetMovie",
                new { id = domainMovie.Id },
                _mapper.Map<MovieReadDTO>(domainMovie));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_repository.MovieExists(id))
                return NotFound();

            await _repository.DeleteMovieAsync(id);

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoMovie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieUpdateDTO dtoMovie)
        {
            if (id != dtoMovie.Id)
                return BadRequest();

            if (!_repository.MovieExists(id))
                return NotFound();

            Movie domainMovie = _mapper.Map<Movie>(dtoMovie);
            await _repository.UpdateMovieAsync(domainMovie);

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characterIds"></param>
        /// <returns></returns>
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> UpdateMovieCharacters(int id, int[] characterIds)
        {
            if (!_repository.MovieExists(id))
                return NotFound();

            await _repository.UpdateCharactersInMovie(id, characterIds);

            return NoContent();
        }
    }
}
