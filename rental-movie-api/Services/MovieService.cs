using rental_movie_api.Entities;
using rental_movie_api.Interfaces.Repositories;
using rental_movie_api.Interfaces.Services;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace rental_movie_api.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _repository.GetAll();
        }

        public Task<Movie> GetMovieById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<Movie> Create(Movie model)
        {
            return await _repository.Create(model);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task DeleteMany(IEnumerable<int> listIds)
        {
            await _repository.DeleteList(listIds);
        }

        public async Task Update(Movie model)
        {
            await _repository.Update(model);
        }
    }
}
