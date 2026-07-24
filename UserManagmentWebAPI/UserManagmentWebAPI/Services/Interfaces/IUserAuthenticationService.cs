using UserManagementWebAPI.Response;
using UserManagmentWebAPI.DTO_s.Authentication;


namespace UserManagmentWebAPI.Services.Interfaces
{
    public interface IUserAuthenticationService
    {
        public Task<ApiResponse<string>> RegisterUserAsync(CreateUserDto request);
        public Task<ApiResponse<string>> LoginAsync(LoginRequest request);
    }
}
