using Microsoft.EntityFrameworkCore;
using University.Domain.Entities.Users;
using University.Domain.Service;
using University.Shared.Enumes;

namespace University.Infrastructure.Database.Initsializers
{
    public static class UserInitializer
    {
        public static void InitializeUser(this ModelBuilder modelBuilder)
        {
            IEnumerable<User> userSeed = new List<User>()
            {
                new User()
                {
                    FirstName = "admin",
                    LastName = "admin",
                    Email = "1",
                    Role = Role.Admin,
                    PrivateNumber = "admin",
                    BirtsDate = DateTime.Now,
                    PhoneNumber = "admin",
                }
            };

            AuthService authService = new AuthService();

            byte[] pasHesh;
            byte[] pasSalt;

            foreach (var user in userSeed)
            {
                authService.CreatePasswordHash("1", out pasHesh, out pasSalt);
                user.PasswordHash = pasHesh;
                user.PasswordSalt = pasSalt;
            }

            modelBuilder.Entity<User>()
                .HasData(userSeed);
        }
    }
}
