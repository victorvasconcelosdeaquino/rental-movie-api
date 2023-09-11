using rental_movie_api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rental_movie_api.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetById(int id);
        Task<Genre> Create(Genre model);
        Task Update(Genre model);
        Task Delete(int model);
    }
}
