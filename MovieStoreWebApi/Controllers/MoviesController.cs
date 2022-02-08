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
        /// Get movie with the specified id from the table
        /// </summary>
        /// <param name="id">The id of the movie to be retrieved</param>
        /// <returns>Returns the movie</returns>
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
        /// Get all movies from the table
        /// </summary>
        /// <returns>Returns an IEnumerable List of all movies</returns>
        [HttpGet]
        public async Task<IEnumerable<MovieReadDTO>> GetAllMovies()
        {
            var movies = await _repository.GetAllMoviesAsync();
            var dtoMovies = _mapper.Map<List<MovieReadDTO>>(movies);

            return dtoMovies;
        }

        /// <summary>
        /// Get all the characters of the specified movie
        /// </summary>
        /// <param name="id">The id of the movie to get the characters from</param>
        /// <returns>Returns an IEnumarable list of characters</returns>
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
        /// Add the provided movie to the table
        /// </summary>
        /// <param name="dtoMovie">The movie to be added</param>
        /// <returns>Returns the movie that was added</returns>
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
        /// Delete a specific movie with id from the table
        /// </summary>
        /// <param name="id">The id of the specific movie</param>
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
        /// Updates the fields of the specified movie
        /// </summary>
        /// <param name="id">The id of the movie to be updated</param>
        /// <param name="dtoMovie">The new values of the movie</param>
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
        /// Updates the characters of the specified movie
        /// </summary>
        /// <param name="id">The id of the movie to updates the characters of</param>
        /// <param name="characterIds">A list of ids corresponding to the new characters</param>
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
