﻿using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Data;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreWebApi.Repositories
{
	public class MovieRepository : IMovieRepository
	{
		private readonly MovieStoreDbContext _context;

		public MovieRepository(MovieStoreDbContext context)
		{
			_context = context;
		}

		public bool MovieExists(int id)
		{
			return _context.Movies
				.Any(movie => movie.Id == id);
		}

		public async Task<Movie> AddMovieAsync(Movie movie)
		{
			_context.Movies.Add(movie);
			await _context.SaveChangesAsync();

			return movie;
		}

		public async Task DeleteMovieAsync(int id)
		{
			var movie = await _context.Movies.FindAsync(id);
			_context.Movies.Remove(movie);

			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
		{
			return await _context.Movies
				.Include(movie => movie.Characters)
				.ToListAsync();
		}

		public async Task<Movie> GetSpecificMovieAsync(int id)
		{
			return await _context.Movies
				.Include(movie => movie.Characters)
				.FirstOrDefaultAsync(movie => movie.Id == id);
		}
		
		public async Task<IEnumerable<Character>> GetAllCharactersInMovie(int id)
		{
			var movie = await _context.Movies
				.Include(movie => movie.Characters)
				.FirstOrDefaultAsync(movie => movie.Id == id);

			var movieCharacters = new List<Character>();

			foreach (var character in movie.Characters)
				movieCharacters.Add(character);

			return movieCharacters;
		}

		public async Task UpdateMovieAsync(Movie movie)
		{
			_context.Entry(movie).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task UpdateCharactersInMovie(int id, int[] characterIds)
		{
			// Getting movie with specific id
			var movie = await _context.Movies
				.Include(movie => movie.Characters)
				.FirstOrDefaultAsync(movie => movie.Id == id);

			var newCharacters = new List<Character>();

			// Creating the new list of characters
			foreach (var characterId in characterIds)
			{
				var character = _context.Characters
					.Where(character => character.Id == characterId)
					.FirstOrDefault();
				
				newCharacters.Add(character);
			}

			// Updating the movie with the new characters
			movie.Characters = newCharacters;

			_context.Entry(movie).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
