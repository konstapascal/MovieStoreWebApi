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

        [MaxLength(500)]
        public string Description { get; set; }

        // 1 Franchise has many Movies
        public ICollection<Movie> Movies { get; set; }
    }
}
