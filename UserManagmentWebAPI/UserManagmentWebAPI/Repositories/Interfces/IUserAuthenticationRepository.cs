using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Authentication;

namespace UserManagementWebAPI.Repositories.Interfces
{
    public interface IUserAuthenticationRepository
    {
        public Task<User> RegisterUserAsync(User user);

        public Task<User> GetByIdentifierAsync(string identifier);

        public Task<bool> LoginAsync(LoginRequest request);
    }
}
