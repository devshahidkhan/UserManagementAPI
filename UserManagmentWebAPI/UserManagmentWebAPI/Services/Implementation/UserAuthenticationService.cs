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
        private readonly ILogger<UserAuthenticationService> _logger;

        public UserAuthenticationService(IUserAuthenticationRepository authenticationRepository,IPasswordHasher passwordHasher,ILogger<UserAuthenticationService> logger) 
        {
            _authenticationRepository = authenticationRepository;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task<string> RegisterUserAsync(CreateUserRequest request)
        {
            var response = await _authenticationRepository.GetByEmailAsync(request.Email);
            if (response !=null)
            {
                return "Email already exists.";
            }
            var user = request.ToEntity();
            await _passwordHasher.CreateHash(request.Password, out byte[] hash, out byte[] salt);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            await _authenticationRepository.RegisterUserAsync(user);
            return "User registered successfully.";
        }

        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await _authenticationRepository.GetByEmailAsync(request.email);
            if (user == null)
            {
                return "Eamil or password are wrong";
            }
            await _passwordHasher.VerifyPassword(request.password, user.PasswordHash, user.PasswordSalt);
            return "Login Successfully";
        }
    }
}
