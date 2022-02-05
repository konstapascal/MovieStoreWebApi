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
					.ForMember(fdto => fdto.Movies, opt => opt.MapFrom(f => f.Movies.Select(m => m.Id).ToList()));

			// FranchiseCreateDTO -> Franchise
			CreateMap<FranchiseCreateDTO, Franchise>();

			// FranchiseUpdateDTO -> Franchise
			CreateMap<FranchiseUpdateDTO, Franchise>();
		}
	}
}
