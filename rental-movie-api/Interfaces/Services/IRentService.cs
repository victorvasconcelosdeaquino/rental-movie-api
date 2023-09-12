using rental_movie_api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rental_movie_api.Interfaces.Services
{
    public interface IRentService
    {
        Task<IEnumerable<Rent>> GetRentals();
        Task<Rent> GetRentById(int id);
        Task<Rent> Create(Rent model);
        Task Update(Rent model);
        Task Delete(int model);
    }
}
