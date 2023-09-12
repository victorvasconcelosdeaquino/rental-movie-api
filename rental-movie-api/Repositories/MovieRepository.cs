using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using rental_movie_api.Data;
using rental_movie_api.Entities;
using rental_movie_api.Exceptions;
using rental_movie_api.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace rental_movie_api.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _dbContext;

        public MovieRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _dbContext.Movies
                .Where(movie => movie.IsActive)
                .ToListAsync();
        }

        public async Task<Movie> GetById(int id)
        {
            var movie = await _dbContext.Movies
                .Where(movie => movie.IsActive && movie.Id == id)
                .FirstOrDefaultAsync();

            if (movie is null)
                throw new NotFoundException("No movie found");
            return movie;
        }

        public async Task<Movie> Create(Movie model)
        {
            using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    model.CreationDate = DateTime.Now;

                    await _dbContext.Movies.AddAsync(model);
                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();

                    return model;
                }
                catch (Exception)
                {
                    transaction.Rollback();

                    return null;
                }
            }
        }

        public async Task Delete(int id)
        {
            var movie = await _dbContext.Movies
                .Where(movie => movie.IsActive && movie.Id == id)
                .FirstOrDefaultAsync();

            if (movie is null)
                throw new NotFoundException("No movie found");

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Movie model)
        {
            var movie = await _dbContext.Movies
                .Where(movie => movie.IsActive && movie.Id == model.Id)
                .FirstOrDefaultAsync();

            if (movie is null)
                throw new NotFoundException("No movie found");

            movie.Name = model.Name;
            movie.IsActive = model.IsActive;
            movie.GenreId = model.GenreId;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteList(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                var movie = await _dbContext.Movies
                .Where(movie => movie.IsActive && movie.Id == id)
                .FirstOrDefaultAsync();

                if (movie is null)
                    throw new NotFoundException("No genre found");

                _dbContext.Movies.Remove(movie);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
