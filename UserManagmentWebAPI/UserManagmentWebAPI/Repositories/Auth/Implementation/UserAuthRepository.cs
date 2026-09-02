using Microsoft.EntityFrameworkCore;
using UserManagementWebAPI.Data;
using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.Repositories.Auth.Interfces;

namespace UserManagementWebAPI.Repositories.Auth.Implementation
{
    public class UserAuthRepository(ApplicationDbContext context): IUserAuthRepository
    {
        public async Task<User> RegisterUserAsync(User user)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email || x.UserName == user.UserName || x.Contact == user.Contact);
            if (existingUser is null)
            {
                await context.AddAsync(user);
                await context.SaveChangesAsync();
                return null;
            }
            return existingUser;

        }

        public async Task<User?> GetByIdentifierAsync(string identifier)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == identifier || x.UserName == identifier || x.Contact == identifier);
        }
    }
}
