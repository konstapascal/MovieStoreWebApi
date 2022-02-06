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

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            var movie = await _repository.GetSpecificMovieAsync(id);

            if (movie == null)
                return NotFound();

            var dtoMovie = _mapper.Map<MovieReadDTO>(movie);

            return dtoMovie;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieReadDTO>> GetAllMovies()
        {
            var movies = await _repository.GetAllMoviesAsync();
            var dtoMovies = _mapper.Map<List<MovieReadDTO>>(movies);

            return dtoMovies;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(MovieCreateDTO dtoMovie)
        {
            var domainMovie = _mapper.Map<Movie>(dtoMovie);

            domainMovie = await _repository.AddMovieAsync(domainMovie);

            return CreatedAtAction("GetMovie",
                new { id = domainMovie.Id },
                _mapper.Map<MovieReadDTO>(domainMovie));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_repository.MovieExists(id))
                return NotFound();

            await _repository.DeleteMovieAsync(id);

            return NoContent();

        }

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
    }
}
