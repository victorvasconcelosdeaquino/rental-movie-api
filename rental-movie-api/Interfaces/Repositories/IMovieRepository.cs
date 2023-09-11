using rental_movie_api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rental_movie_api.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> GetById(int id);
        Task<Movie> Create(Movie model);
        Task Update(Movie model);
        Task Delete(int id);
        Task DeleteList(IEnumerable<int> ids);
    }
}
