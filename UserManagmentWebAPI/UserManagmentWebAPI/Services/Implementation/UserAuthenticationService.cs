using UserManagmentWebAPI.DTO_s.Authentication;
using UserManagmentWebAPI.Entities;
using UserManagmentWebAPI.Extentions.Mappers.UserMapper;
using UserManagmentWebAPI.Repositories.Interfces;
using UserManagmentWebAPI.Services.Interfaces;


namespace UserManagmentWebAPI.Services.Implementation
{
    public class UserAuthenticationService:IUserAuthenticationService
    {
        private readonly IUserAuthenticationRepository _authenticationRepository;
        private readonly IPasswordHasher _passwordHasher; 

        public UserAuthenticationService(IUserAuthenticationRepository authenticationRepository,IPasswordHasher passwordHasher) 
        {
            _authenticationRepository = authenticationRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> RegisterUserAsync(CreateUserRequest request)
        {
            var user = request.ToEntity();
            await _passwordHasher.CreateHash(request.Password, out byte[] hash, out byte[] salt);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            await _authenticationRepository.RegisterUserAsync(user);
            return "User registered successfully.";
        }
    }
}
