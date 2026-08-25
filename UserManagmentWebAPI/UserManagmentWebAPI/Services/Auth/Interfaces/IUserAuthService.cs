using UserManagementWebAPI.DTO_s.Auth;
using UserManagementWebAPI.Response;

namespace UserManagementWebAPI.Services.Auth.Interfaces
{
    public interface IUserAuthService
    {
        Task<ApiResponse<string>> RegisterUserAsync(RegisterUserDto request);
        Task<ApiResponse<string>> LoginAsync(LoginDto request);
    }
}
