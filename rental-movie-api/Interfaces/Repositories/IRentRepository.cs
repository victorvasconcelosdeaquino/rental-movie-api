using rental_movie_api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rental_movie_api.Interfaces.Repositories
{
    public interface IRentRepository
    {
        Task<IEnumerable<Rent>> GetAll();
        Task<Rent> GetById(int id);
        Task<Rent> Create(Rent model);
        Task Update(Rent model);
        Task Delete(int model);
    }
}
