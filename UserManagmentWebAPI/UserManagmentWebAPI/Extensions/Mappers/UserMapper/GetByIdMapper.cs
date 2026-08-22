using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Users;

namespace UserManagementWebAPI.Extensions.Mappers.UserMapper
{
    public static class GetByIdMapper
    {
        public static GetByIdDto MapToDto(this User user)
        {
            return new GetByIdDto
                (
                user.UserId,
                user.FullName,
                user.UserName,
                user.Email,
                user.Contact,
                user.Address,
                user.Role
                );
        }
    }
}
