namespace UserManagmentWebAPI.Services.Interfaces
{
    public interface IPasswordHasher
    {
        public Task CreateHash(string password ,out byte[] hash ,out byte[] salt); 
    }
}