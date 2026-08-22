using UserManagementWebAPI.Response;
using UserManagementWebAPI.DTO_s.Authentication;


namespace UserManagementWebAPI.Services.Auth.Interfaces
{
    public interface IUserAuthenticationService
    {
        public Task<ApiResponse<string>> RegisterUserAsync(RegisterUserDto request);
        public Task<ApiResponse<string>> LoginAsync(LoginRequest request);
    }
}
