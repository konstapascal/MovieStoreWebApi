using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Models.Domain
{
    [Table("Character")]
    public class Character
    {
        // Properties
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Alias { get; set; }

        [Required]
        [MaxLength(50)]
        public string Gender { get; set; }

        [Url]
        [MaxLength(500)]
        public string ImageUrl { get; set; }

        // Relationships
        // 1 character can have many movies
        public ICollection<Movie> Movies { get; set; }
    }
}
