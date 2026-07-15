using System.Runtime.CompilerServices;
using UserManagmentWebAPI.DTO_s.Authentication;
using UserManagmentWebAPI.Entities;

namespace UserManagmentWebAPI.Extentions.Mappers.UserMapper
{
    public static class CreateUserMapper
    {
        public static User ToEntity(this CreateUserRequest request)
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
