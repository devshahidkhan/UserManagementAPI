using UserManagementWebAPI.DTO_s.Users;
using UserManagementWebAPI.Repositories.Users.Interface;
using UserManagementWebAPI.Services.Users.Interface;
using UserManagementWebAPI.Extensions.Mappers.UserMapper;

namespace UserManagementWebAPI.Services.Users.Implementation
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetUsersDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return users.MapUsersToDto();
        }

        public async Task<GetByIdDto> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user.MapUserToDto();
        }

        public async Task<bool> Update(Guid id, UpdateDto request)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user is null)
            {
                return false;
            }

            request.MapDtoToUser(user);
            await _userRepository.Update(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
           return await _userRepository.DeleteUserAsync(id);
            
        }
    }
}
