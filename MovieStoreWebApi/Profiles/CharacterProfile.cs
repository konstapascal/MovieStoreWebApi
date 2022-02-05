using AutoMapper;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Character;
using System.Linq;

namespace MovieStoreWebApi.Profiles
{
	public class CharacterProfile : Profile
	{
		public CharacterProfile()
		{
			// Character -> CharacterReadDTO
			CreateMap<Character, CharacterReadDTO>()
					.ForMember(dto => dto.Movies, opt => opt.MapFrom(character => character.Movies.Select(movie => movie.Id)));

			// CharacterCreateDTO -> Character
			CreateMap<CharacterCreateDTO, Character>();

			// CharacterUpdateDTO -> Character
			CreateMap<CharacterUpdateDTO, Character>();
		}
	}
}
