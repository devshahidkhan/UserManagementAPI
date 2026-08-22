using UserManagementWebAPI.DTO_s.Users;
using UserManagementWebAPI.Repositories.Users.Interface;
using UserManagementWebAPI.Services.Users.Interface;
using UserManagementWebAPI.Extensions.Mappers.UserMapper;

namespace UserManagementWebAPI.Services.Users.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> CreateUserAsync(CreateUserDto request)
        {
            var user = request.MapToUser();
            await _userRepository.AddUserAsync(user);
            return "User Saved Successfully!";
        }

        public async Task<GetByIdDto> GetByIdAsync(Guid id)
        {
            var userDto = await _userRepository.GetByIdAsync(id);
            return userDto.MapToDto();
        }

        public async Task<List<GetUsersDto>> GetUsersAsync()
        {
            var usersDto = await _userRepository.GetUsersAsync();
            return usersDto.MapToDto();
        }

        public async Task<string> UpdateUser(Guid id, UpdateUserDto request)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return "User not found!";
            request.MapToUser(user);
            await _userRepository.UpdateUser(user);
            return "Update Successfully!";
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
