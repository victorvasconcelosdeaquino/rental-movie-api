using Microsoft.EntityFrameworkCore;
using rental_movie_api.Entities;

namespace rental_movie_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<Rent>? Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
                .HasOne<Genre>(c => c.Genre)
                .WithMany(c => c.Movies)
                .HasForeignKey(c => c.GenreId);

            base.OnModelCreating(builder);
        }
    }
}
