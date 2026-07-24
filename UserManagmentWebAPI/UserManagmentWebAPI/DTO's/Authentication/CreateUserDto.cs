using System.ComponentModel.DataAnnotations;
using UserManagmentWebAPI.Enums;

namespace UserManagmentWebAPI.DTO_s.Authentication
{
    public record CreateUserDto
    (
       Guid UserId,
       string FullName,
       string UserName,
       string Email,
       string Contact,
       string Address,
       //Role Role,
       string Password
    );
}
