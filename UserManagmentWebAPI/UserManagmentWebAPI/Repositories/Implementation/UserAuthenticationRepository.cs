using UserManagmentWebAPI.Data;
using UserManagmentWebAPI.Entities;
using UserManagmentWebAPI.Repositories.Interfces;

namespace UserManagmentWebAPI.Repositories.Implementation
{
    public class UserAuthenticationRepository: IUserAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;

        public UserAuthenticationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RegisterUserAsync(User user)
        {
           await _context.AddAsync(user);
           await _context.SaveChangesAsync();
           
        }
    }
}
