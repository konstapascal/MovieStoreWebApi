using AutoMapper;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Character;
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
				.ForMember(cdto => cdto.Characters, opt => opt.MapFrom(c => c.Characters.Select(c => c.Id).ToList()));

			// MovieCreateDTO -> Movie
			CreateMap<MovieCreateDTO, Movie>();

			// MovieUpdateDTO -> Movie
			CreateMap<CharacterUpdateDTO, Character>();
		}
	}
}
