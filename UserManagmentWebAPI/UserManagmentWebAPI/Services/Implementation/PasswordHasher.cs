using System.Security.Cryptography;
using System.Text;
using UserManagmentWebAPI.Services.Interfaces;

namespace UserManagmentWebAPI.Services.Implementation
{
    public class PasswordHasher : IPasswordHasher
    {
        public Task CreateHash(string password, out byte[] hash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Task.CompletedTask;
        }
    }
}
