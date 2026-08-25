using Microsoft.EntityFrameworkCore;
using UserManagementWebAPI.Data;
using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.Repositories.Auth.Interfces;

namespace UserManagementWebAPI.Repositories.Auth.Implementation
{
    public class UserAuthRepository: IUserAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public UserAuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email || x.UserName == user.UserName || x.Contact == user.Contact);
            if (existingUser is null)
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return null;
            }
            return existingUser;

        }

        public async Task<User?> GetByIdentifierAsync(string identifier)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == identifier || x.UserName == identifier || x.Contact == identifier);
        }
    }
}
