namespace UserManagementWebAPI.DTO_s.Auth
{
    public record RegisterUserDto
    (
       string FullName,
       string UserName,
       string Email,
       string Contact,
       string Address,
       string Password
    );
}
