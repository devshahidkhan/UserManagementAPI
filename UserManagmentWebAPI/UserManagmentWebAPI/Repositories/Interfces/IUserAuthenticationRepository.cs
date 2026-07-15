using UserManagmentWebAPI.Entities;

namespace UserManagmentWebAPI.Repositories.Interfces
{
    public interface IUserAuthenticationRepository
    {
        public Task RegisterUserAsync(User user);
    }
}
