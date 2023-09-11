using rental_movie_api.Entities;

namespace rental_movie_api.ServiceExtensions
{
    public interface ITokenService
    {
        string GenerateToken(string key, string issuer, string audience, UserModel user);
    }
}
