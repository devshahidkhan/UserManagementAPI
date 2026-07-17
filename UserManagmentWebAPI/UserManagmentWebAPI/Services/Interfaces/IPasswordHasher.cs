namespace UserManagmentWebAPI.Services.Interfaces
{
    public interface IPasswordHasher
    {
        public Task CreateHash(string password ,out byte[] hash ,out byte[] salt); 
        public Task<bool> VerifyPassword(string password, byte[] storedHash, byte[] storedSalt);
    }
}