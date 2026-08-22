using UserManagementWebAPI.Enums;

namespace UserManagementWebAPI.DTO_s.Users
{
    public record GetUsersDto
        (
             string FullName,
             string UserName,
             string Email,
             string Contact,
             string Address
        );
}
