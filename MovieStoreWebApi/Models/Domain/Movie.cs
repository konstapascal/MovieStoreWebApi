using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Models.Domain
{
    [Table("Movie")]
    public class Movie
    {
        // Properties
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }

        [Required]
        [MaxLength(4)]
        public int ReleaseYear { get; set; }

        [Required]
        [MaxLength(50)]
        public string Director { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; }

        [MaxLength(500)]
        public string TrailerUrl { get; set; }

        // Relationships
        // 1 movie can have 1 franchise
        public int? FranchiseId { get; set; }
        public Franchise Franchise { get; set; }
        
        // 1 movie can have many characters
        public ICollection<Character> Characters { get; set; }
    }
}
