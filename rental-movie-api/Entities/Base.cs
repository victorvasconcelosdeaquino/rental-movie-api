using System.ComponentModel.DataAnnotations;

namespace rental_movie_api.Entities
{
    public class Base<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
