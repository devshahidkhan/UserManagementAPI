using System.ComponentModel.DataAnnotations;
using UserManagementWebAPI.Data.Entities;


namespace UserManagementWebAPI.Services.Auth.Interfaces
{
    public interface IJwtTokenService
    {
       public Task<string> GenerateTokenAsync(User user);
    }
}