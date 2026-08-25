using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Auth;

namespace UserManagementWebAPI.Extensions.Mappers.AuthMapper
{
    public static class RegisterUserMapper
    {
        public static User ToEntity(this RegisterUserDto request)
        {
            return new User
            {
                UserId = Guid.NewGuid(),
                FullName = request.FullName,
                UserName = request.UserName,
                Email = request.Email,
                Contact = request.Contact,
                Address = request.Address,
            };
        }
    }
}
