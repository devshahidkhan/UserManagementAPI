using System.ComponentModel.DataAnnotations;
using System.Data;
using UserManagmentWebAPI.Enums;

namespace UserManagmentWebAPI.Data.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = [];
        public byte[] PasswordSalt { get; set; } = [];
        public string Contact { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.Admin;
    }
}
