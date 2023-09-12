using rental_movie_api.Entities;
using rental_movie_api.Interfaces.Repositories;
using rental_movie_api.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rental_movie_api.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _repository;

        public RentService(IRentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Rent>> GetRentals()
        {
            return await _repository.GetAll();
        }

        public async Task<Rent> GetRentById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Rent> Create(Rent model)
        {
            return await _repository.Create(model);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task Update(Rent model)
        {
            await _repository.Update(model);
        }
    }
}
