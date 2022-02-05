using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Character;
using MovieStoreWebApi.Models.DTOs.Movie;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
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
            var movie = await _repository.ReadSpecificMovieAsync(id);

            if (movie == null)
                return NotFound();

            var dtoMovie = _mapper.Map<MovieReadDTO>(movie);

            return dtoMovie;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieReadDTO>> GetMovies()
        {
            var movies = await _repository.ReadAllMoviesAsync();
            var dtoMovies = _mapper.Map<List<MovieReadDTO>>(movies);

            return dtoMovies;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!_repository.MovieExists(id))
                return NotFound();

            await _repository.DeleteMovieAsync(id);

            return NoContent();

        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO dtoMovie)
        {
            var domainMovie = _mapper.Map<Movie>(dtoMovie);

            domainMovie = await _repository.CreateMovieAsync(domainMovie);

            return CreatedAtAction("GetMovie",
                new { id = domainMovie.Id },
                _mapper.Map<MovieReadDTO>(domainMovie));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieUpdateDTO dtoMovie)
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
