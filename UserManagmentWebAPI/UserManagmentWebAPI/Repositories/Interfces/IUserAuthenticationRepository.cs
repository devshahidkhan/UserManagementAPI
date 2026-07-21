using UserManagmentWebAPI.Data.Entities;
using UserManagmentWebAPI.DTO_s.Authentication;

namespace UserManagmentWebAPI.Repositories.Interfces
{
    public interface IUserAuthenticationRepository
    {
        public Task<User> RegisterUserAsync(User user);

        public Task<User> GetByIdentifierAsync(string identifier);

        public Task<bool> LoginAsync(LoginRequest request);
    }
}
