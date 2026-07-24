using System.Runtime.CompilerServices;
using UserManagmentWebAPI.Data.Entities;
using UserManagmentWebAPI.DTO_s.Authentication;

namespace UserManagmentWebAPI.Extentions.Mappers.UserMapper
{
    public static class CreateUserMapper
    {
        public static User ToEntity(this CreateUserDto request)
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
