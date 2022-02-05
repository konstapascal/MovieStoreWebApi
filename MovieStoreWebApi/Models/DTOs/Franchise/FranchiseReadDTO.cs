using System.Collections.Generic;
using System;

namespace MovieStoreWebApi.Models.DTOs.Franchise
{
	public class FranchiseReadDTO
	{
        public string Name { get; set; }
        public string Description { get; set; }
		public List<int> Movies { get; set; }
	}
}
