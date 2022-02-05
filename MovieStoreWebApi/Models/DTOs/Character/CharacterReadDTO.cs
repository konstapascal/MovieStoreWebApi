using System.Collections.Generic;
using System;

namespace MovieStoreWebApi.Models.DTOs.Character
{
	public class CharacterReadDTO
	{
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public List<int> Movies { get; set; }
    }
}
