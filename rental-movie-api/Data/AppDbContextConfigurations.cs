using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace rental_movie_api.Data
{
    public class AppDbContextConfigurations
    {
        public static void Configure(ModelBuilder mb)
        {
            mb.Entity<IdentityUser>().ToTable("Users");
            mb.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
