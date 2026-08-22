using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Users;

namespace UserManagementWebAPI.Services.Users.Interface
{
    public interface IUserService
    {
        Task<string> CreateUserAsync(CreateUserDto request);
        Task<GetByIdDto> GetByIdAsync(Guid id);
        Task<List<GetUsersDto>> GetUsersAsync();
        Task<string> UpdateUser(Guid id, UpdateUserDto request);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
