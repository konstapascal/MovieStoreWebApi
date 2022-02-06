using System.Collections.Generic;

namespace MovieStoreWebApi.Models.DTOs.Movie
{
	public class MovieCharacterDTO
	{
		public string FullName { get; set; }
		public string Alias { get; set; }
		public string Gender { get; set; }
		public string ImageUrl { get; set; }
	}
}
