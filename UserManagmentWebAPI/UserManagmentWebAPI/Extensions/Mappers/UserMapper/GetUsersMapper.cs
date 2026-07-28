using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Users;

namespace UserManagementWebAPI.Extensions.Mappers.UserMapper
{
    public static class GetUsersMapper
    {
        public static List<GetUsersDto> MapUsersToDto( this List<User> users)
        {
            List<GetUsersDto> list = new List<GetUsersDto>();

            foreach (var user in users)
            {
                GetUsersDto dto = new GetUsersDto(
                    user.FullName,
                    user.UserName,
                    user.Email,
                    user.Contact,
                    user.Address,
                    user.Role
                );

                list.Add(dto);
            }
            return list;
        }
    }
}
