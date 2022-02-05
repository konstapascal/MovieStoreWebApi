using System;

namespace MovieStoreWebApi.Models.DTOs.Movie
{
	public class MovieUpdateDTO
	{
		public int Id { get; set; }
		public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public int FranchiseId { get; set; }

    }
}
