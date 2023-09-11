using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace rental_movie_api.Entities
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DocumentNumber { get; set; }
        public DateTime RentDate { get; set; }
        //Todo: Is necessary to create a devolution date
        public int MovieId { get; set;}
        [JsonIgnore]
        public Movie Movie { get; set; }

    }
}
