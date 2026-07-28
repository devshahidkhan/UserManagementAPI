using UserManagementWebAPI.Data.Entities;

namespace UserManagementWebAPI.Repositories.Users.Interface
{
    public interface IUserRepository
    {
        //Get the Uer Short Info
        public Task<List<User>> GetUsersAsync();
        //Get the User Complete Info
        public Task<User> GetByIdAsync(Guid id);

        public Task Update(User user);

        public Task<bool> DeleteUserAsync(Guid id);
    }
}
