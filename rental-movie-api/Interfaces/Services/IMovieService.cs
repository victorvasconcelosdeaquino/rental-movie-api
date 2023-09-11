using rental_movie_api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rental_movie_api.Interfaces.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> Create(Movie model);
        Task Update(Movie model);
        Task Delete(int model);
        Task DeleteMany(IEnumerable<int> listIds);
    }
}
