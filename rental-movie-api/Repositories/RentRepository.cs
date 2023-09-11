using Microsoft.EntityFrameworkCore;
using rental_movie_api.Data;
using rental_movie_api.Entities;
using rental_movie_api.Exceptions;
using rental_movie_api.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rental_movie_api.Repositories
{
    public class RentRepository : IRentRepository
    {
        private readonly AppDbContext _dbContext;

        public RentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Rent>> GetAll()
        {
            return await _dbContext.Rents.ToListAsync();
        }

        public async Task<Rent> GetById(int id)
        {
            var rent = await _dbContext.Rents.FindAsync(id);
            if (rent is null)
                throw new NotFoundException("No genre found");
            return rent;
        }

        public async Task<Rent> Create(Rent model)
        {
            //Todo: create a validation to check if the movie is able to rent based on devolution date

            await _dbContext.Rents.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task Delete(int id)
        {
            var rent = await _dbContext.Rents.FindAsync(id);
            if (rent is null)
                throw new NotFoundException("No rent found");

            _dbContext.Rents.Remove(rent);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Rent model)
        {
            var rent = await _dbContext.Rents.FindAsync(model.Id);
            if (rent is null)
                throw new NotFoundException("No rent found");

            //Todo: after validation function created, put the method here to check

            rent.RentDate = model.RentDate;
            rent.DocumentNumber = model.DocumentNumber;
            rent.MovieId = model.MovieId;

            await _dbContext.SaveChangesAsync();
        }
    }
}
