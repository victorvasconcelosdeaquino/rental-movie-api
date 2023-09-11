using Microsoft.Extensions.DependencyInjection;
using rental_movie_api.Interfaces.Repositories;
using rental_movie_api.Interfaces.Services;
using rental_movie_api.Repositories;
using rental_movie_api.Services;

namespace rental_movie_api.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //Registering token service to use in authentication
            services.AddSingleton<ITokenService>(new TokenService());

            #region Services
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IRentService, RentService>();

            #endregion  Services

            #region Repositories
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IRentRepository, RentRepository>();

            #endregion Repositories

            return services;
        }
    }
}
