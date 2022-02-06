using AutoMapper;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Character;
using MovieStoreWebApi.Models.DTOs.Franchise;
using MovieStoreWebApi.Models.DTOs.Movie;
using System.Linq;

namespace MovieStoreWebApi.Profiles
{
	public class MovieProfile : Profile
	{
		public MovieProfile()
		{
			// Movie -> MovieReadDTO
			CreateMap<Movie, MovieReadDTO>()
				.ForMember(movieDto => movieDto.Characters, opt => opt
				.MapFrom(movie => movie.Characters
				.Select(character => character.Id)
				.ToList()));

			// Movie -> FranchiseMovieDTO
			CreateMap<Movie, FranchiseMovieDTO>();

			// MovieCreateDTO -> Movie
			CreateMap<MovieCreateDTO, Movie>();

			// MovieUpdateDTO -> Movie
			CreateMap<CharacterUpdateDTO, Character>();
		}
	}
}
