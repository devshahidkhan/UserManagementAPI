using System.Security.Cryptography;
using System.Text;
using UserManagmentWebAPI.Services.Interfaces;

namespace UserManagmentWebAPI.Services.Implementation
{
    public class PasswordHasher : IPasswordHasher
    {
        public Task CreateHash(string password, out byte[] hash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();  //create the object of HMACSHA512(). When you run than internally generate the random secrate key with help of secure random-number generator 
            salt = hmac.Key; //Copies the random bytes of hmac.Key into the salt variable.
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //(Encoding.UTF8.GetBytes(password))--> First Convert the string password into bytes array
            //--> Use the Password HMAC key/Salt to generate the secure Hash
            return Task.CompletedTask;//This tell the method work is complete
        }

        public Task<bool> VerifyPassword( string password,byte[] storedHash,byte[] storedSalt)
        {
            using var hmac = new HMACSHA512(storedSalt);

            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            bool isValid = computedHash.SequenceEqual(storedHash);

            return Task.FromResult(isValid);
        }
    }
}
