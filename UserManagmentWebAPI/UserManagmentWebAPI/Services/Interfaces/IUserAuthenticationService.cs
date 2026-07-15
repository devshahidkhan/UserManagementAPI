using UserManagmentWebAPI.DTO_s.Authentication;
using UserManagmentWebAPI.Entities;

namespace UserManagmentWebAPI.Services.Interfaces
{
    public interface IUserAuthenticationService
    {
        public Task<string> RegisterUserAsync(CreateUserRequest request);
    }
}
