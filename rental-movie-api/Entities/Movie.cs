using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace rental_movie_api.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 200)]
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool IsActive { get; set; }

        public int GenreId { get; set; }
        [JsonIgnore]
        public Genre Genre { get; set; }
    }
}
