using AutoMapper;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Character;
using MovieStoreWebApi.Models.DTOs.Franchise;
using MovieStoreWebApi.Models.DTOs.Movie;
using System.Linq;

namespace MovieStoreWebApi.Profiles
{
	public class CharacterProfile : Profile
	{
		public CharacterProfile()
		{
			// Character -> CharacterReadDTO
			CreateMap<Character, CharacterReadDTO>()
					.ForMember(characterDto => characterDto.Movies, opt => opt
					.MapFrom(character => character.Movies
					.Select(movie => movie.Id)
					.ToList()));

			// Character -> FranchiseCharacterDTO
			CreateMap<Character, FranchiseCharacterDTO>();

			// Character -> MovieCharacterDTO
			CreateMap<Character, MovieCharacterDTO>();

			// CharacterCreateDTO -> Character
			CreateMap<CharacterCreateDTO, Character>();

			// CharacterUpdateDTO -> Character
			CreateMap<CharacterUpdateDTO, Character>();
		}
	}
}
