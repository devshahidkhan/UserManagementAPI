using UserManagmentWebAPI.Data.Entities;

namespace UserManagementWebAPI.Services.Interfaces
{
    public interface IJwtTokenService
    {
       Task<string> GenerateTokenAsync(User user);
    }
}
