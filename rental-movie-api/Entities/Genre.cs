using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace rental_movie_api.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool IsActive { get; set; }
        
        [JsonIgnore]
        public ICollection<Movie> Movies { get; set;}
    }
}
