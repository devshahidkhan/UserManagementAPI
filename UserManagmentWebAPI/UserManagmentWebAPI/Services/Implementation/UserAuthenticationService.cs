using UserManagementWebAPI.Response;
using UserManagementWebAPI.Services.Interfaces;
using UserManagmentWebAPI.DTO_s.Authentication;
using UserManagmentWebAPI.Extentions.Mappers.UserMapper;
using UserManagmentWebAPI.Repositories.Interfces;
using UserManagmentWebAPI.Services.Interfaces;


namespace UserManagmentWebAPI.Services.Implementation
{
    public class UserAuthenticationService:IUserAuthenticationService
    {
        private readonly IUserAuthenticationRepository _authenticationRepository;
        private readonly IPasswordHasher _passwordHasher; 
        private readonly IJwtTokenService _jwtTokenService;

        private readonly ILogger<UserAuthenticationService> _logger;

        public UserAuthenticationService(IUserAuthenticationRepository authenticationRepository,IPasswordHasher passwordHasher,IJwtTokenService jwtTokenService,ILogger<UserAuthenticationService> logger) 
        {
            _authenticationRepository = authenticationRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
            _logger = logger;
        }

        public async Task<ApiResponse<string>> RegisterUserAsync(CreateUserDto request)
        {
            try
            {
                var user = request.ToEntity();
                await _passwordHasher.CreateHash(request.Password, out byte[] hash, out byte[] salt);
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                var existingUser = await _authenticationRepository.RegisterUserAsync(user);

                if (existingUser is null)
                {
                    return ApiResponse<string>.Success("User has been Signup Successfully!");
                }
                if (existingUser.Email == request.Email)
                {
                    return ApiResponse<string>.Failure("Email is already exists");
                }
                else if (existingUser.UserName == request.UserName)
                {
                    return ApiResponse<string>.Failure("UserName is already exists.");
                }
                else if (existingUser.Contact == request.Contact)
                {
                    return ApiResponse<string>.Failure("Contact is already exists");
                }
                return ApiResponse<string>.Success("User has been Signup Successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return ApiResponse<string>.Failure(ex.Message);
            }
        }

        public async Task<ApiResponse<string>> LoginAsync(LoginRequest request)
        {
            var user = await _authenticationRepository.GetByIdentifierAsync(request.Identifier);
            if (user is null)
            {
                return ApiResponse<string>.Failure("Couldn't find this account!");
            }
            bool isPasswordValid = await _passwordHasher.VerifyPassword(request.password, user.PasswordHash, user.PasswordSalt);

            if (!isPasswordValid)
            {
                return ApiResponse<string>.Failure("Invalid Password");
            }

            return ApiResponse<string>.Success(await _jwtTokenService.GenerateTokenAsync(user));
        }
    }
}
