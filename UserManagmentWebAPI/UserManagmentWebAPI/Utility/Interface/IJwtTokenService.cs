using System.ComponentModel.DataAnnotations;
using UserManagementWebAPI.Data.Entities;


namespace UserManagementWebAPI.Utility.Interface
{
    public interface IJwtTokenService
    {
       string CreateJwt(User user);
    }
}