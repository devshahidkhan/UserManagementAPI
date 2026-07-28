using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Users;

namespace UserManagementWebAPI.Services.Users.Interface
{
    public interface IUserService
    {
        public Task<List<GetUsersDto>> GetUsersAsync();

        public Task<GetByIdDto> GetByIdAsync(Guid id);

        public Task<bool> Update(Guid id,UpdateDto dto);

        public Task<bool> DeleteUserAsync(Guid id);
    }
}
