using UserManagementWebAPI.Data.Entities;

namespace UserManagementWebAPI.Repositories.Auth.Interfces
{
    public interface IUserAuthRepository
    {
        Task<User> RegisterUserAsync(User user);

        Task<User?> GetByIdentifierAsync(string identifier);

    }
}
