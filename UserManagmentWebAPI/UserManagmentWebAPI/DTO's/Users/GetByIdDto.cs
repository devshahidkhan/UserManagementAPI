using UserManagementWebAPI.Enums;

namespace UserManagementWebAPI.DTO_s.Users
{
    public record GetByIdDto
    (
        Guid UserId,
        string FullName,
        string UserName,
        string Email,
        string Contact,
        string Address,
        Role Role
    );
}
