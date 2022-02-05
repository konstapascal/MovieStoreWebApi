using System;

namespace MovieStoreWebApi.Models.DTOs.Character
{
	public class CharacterUpdateDTO
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Alias { get; set; }
		public string Gender { get; set; }
		public string ImageUrl { get; set; }

	}
}
