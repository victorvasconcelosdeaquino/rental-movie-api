using rental_movie_api.Entities;
using rental_movie_api.Interfaces.Repositories;
using rental_movie_api.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rental_movie_api.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            return await _repository.GetAll();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Genre> Create(Genre model)
        {
            return await _repository.Create(model);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task Update(Genre model)
        {
            await _repository.Update(model);
        }
    }
}
