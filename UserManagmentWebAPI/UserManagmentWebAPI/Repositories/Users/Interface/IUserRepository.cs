using UserManagementWebAPI.Data.Entities;

namespace UserManagementWebAPI.Repositories.Users.Interface
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetByIdAsync(Guid id);
        Task<List<User>> GetUsersAsync();
        Task UpdateUser(User user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
