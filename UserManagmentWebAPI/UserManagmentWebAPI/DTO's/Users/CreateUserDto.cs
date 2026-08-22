namespace UserManagementWebAPI.DTO_s.Users
{
    public record CreateUserDto(
         Guid UserId,
         string FullName,
         string UserName,
         string Email,
         string Contact,
         string Address
        );
}
