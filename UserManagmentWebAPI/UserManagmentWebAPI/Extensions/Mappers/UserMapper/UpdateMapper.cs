using Azure.Core;
using System.Net;
using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Users;

namespace UserManagementWebAPI.Extensions.Mappers.UserMapper
{
    public static class UpdateMapper
    {
        public static void MapToUser(this UpdateUserDto dto, User user)
        {
            user.FullName = dto.FullName;
            user.UserName = dto.UserName;
            user.Email = dto.Email;
            user.Contact = dto.Contact;
            user.Address = dto.Address;
            user.Role = dto.Role;
        }
    }
}
