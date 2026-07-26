using Microsoft.EntityFrameworkCore;
using UserManagementWebAPI.Data;
using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Authentication;
using UserManagementWebAPI.Repositories.Interfces;

namespace UserManagementWebAPI.Repositories.Implementation
{
    public class UserAuthenticationRepository: IUserAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;

        public UserAuthenticationRepository(ApplicationDbContext context)
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

        public async Task<bool> LoginAsync(LoginRequest request)
        {
            var IsValidUser = await _context.Users.AnyAsync(x => x.Email == request.Identifier || x.UserName == request.Identifier || x.Contact == request.Identifier);
            if (IsValidUser)
            {
                return true;
            }
            return false;
        }

        public async Task<User> GetByIdentifierAsync(string identifier)
        {
           var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == identifier || x.UserName == identifier || x.Contact == identifier);
           return user;
        }
    }
}
