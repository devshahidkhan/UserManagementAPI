namespace UserManagementWebAPI.DTO_s.Auth
{
    public record RegisterUserDto
    (
       Guid UserId,
       string FullName,
       string UserName,
       string Email,
       string Contact,
       string Address,
       string Password
    );
}
