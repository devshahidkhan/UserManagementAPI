using UserManagementWebAPI.Response;
using UserManagementWebAPI.DTO_s.Authentication;


namespace UserManagementWebAPI.Services.Interfaces
{
    public interface IUserAuthenticationService
    {
        public Task<ApiResponse<string>> RegisterUserAsync(CreateUserDto request);
        public Task<ApiResponse<string>> LoginAsync(LoginRequest request);
    }
}
