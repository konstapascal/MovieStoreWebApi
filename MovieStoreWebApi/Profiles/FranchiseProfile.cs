using AutoMapper;
using MovieStoreWebApi.Models.Domain;
using MovieStoreWebApi.Models.DTOs.Franchise;
using System.Linq;

namespace MovieStoreWebApi.Profiles
{
	public class FranchiseProfile : Profile
	{
		public FranchiseProfile()
		{
			// Franchise -> FranchiseReadDTO
			CreateMap<Franchise, FranchiseReadDTO>()
					.ForMember(franchiseDto => franchiseDto.Movies, opt => opt
					.MapFrom(franchise => franchise.Movies
					.Select(movie => movie.Id)
					.ToList()));

			// FranchiseCreateDTO -> Franchise
			CreateMap<FranchiseCreateDTO, Franchise>();

			// FranchiseUpdateDTO -> Franchise
			CreateMap<FranchiseUpdateDTO, Franchise>();
		}
	}
}
