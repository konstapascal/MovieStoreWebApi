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

        [MaxLength(50)]
        public string Gender { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; }

        // 1 Character can play in many Movies
        public ICollection<Movie> Movies { get; set; }
    }
}
