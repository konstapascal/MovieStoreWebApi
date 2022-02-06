using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Models.Domain
{
    [Table("Franchise")]
    public class Franchise
    {
        // Properties
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        // Relationships
        // 1 franchise can have many movies
        public ICollection<Movie> Movies { get; set; }
    }
}
