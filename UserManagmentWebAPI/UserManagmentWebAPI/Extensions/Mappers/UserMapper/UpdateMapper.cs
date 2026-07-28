using Azure.Core;
using System.Net;
using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Users;

namespace UserManagementWebAPI.Extensions.Mappers.UserMapper
{
    public static class UpdateMapper
    {
        public static void MapDtoToUser(this UpdateDto request,User user)
        {
            user.FullName = request.FullName;
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.Contact = request.Contact;
            user.Address = request.Address;
            user.Role = request.Role;
        }
    }
}
