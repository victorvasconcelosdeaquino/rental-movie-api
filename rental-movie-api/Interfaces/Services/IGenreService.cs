using rental_movie_api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rental_movie_api.Interfaces.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetGenres();
        Task<Genre> GetGenreById(int id);
        Task<Genre> Create(Genre model);
        Task Update(Genre model);
        Task Delete(int model);
    }
}
