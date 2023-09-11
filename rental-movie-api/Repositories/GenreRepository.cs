using Microsoft.EntityFrameworkCore;
using rental_movie_api.Data;
using rental_movie_api.Entities;
using rental_movie_api.Exceptions;
using rental_movie_api.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace rental_movie_api.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _dbContext;

        public GenreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            var genre = await _dbContext.Genres.FindAsync(id);
            if (genre is null)
                throw new NotFoundException("No genre found");
            return genre;
        }

        public async Task<Genre> Create(Genre model)
        {
            model.CreationDate = DateTime.Now;

            await _dbContext.Genres.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task Delete(int id)
        {
            var genre = await _dbContext.Genres.FindAsync(id);
            if (genre is null)
                throw new NotFoundException("No genre found");

            _dbContext.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Genre model)
        {
            var genre = await _dbContext.Genres.FindAsync(model.Id);
            if (genre is null)
                throw new NotFoundException("No genre found");

            genre.Name = model.Name;
            genre.IsActive = model.IsActive;

            await _dbContext.SaveChangesAsync();
        }
    }
}
