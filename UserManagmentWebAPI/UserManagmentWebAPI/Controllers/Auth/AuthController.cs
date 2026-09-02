//using Microsoft.AspNetCore.Mvc;
//using UserManagementWebAPI.DTO_s.Auth;
//using UserManagementWebAPI.Filters;
//using UserManagementWebAPI.Services.Auth.Interfaces;

//namespace UserManagementWebAPI.Controllers.Auth
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    [ValidateModelState]
//    public class AuthController : ControllerBase
//    {
//        private readonly IUserAuthService _authenticationService;
//        private readonly ILogger<AuthController> _logger;


        
//        public AuthController(IUserAuthService authService, ILogger<AuthController> logger)
//        {
//            _authenticationService = authService;
//            _logger = logger;
//        }

//        [HttpPost("RegisterUser")]
//        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto request)
//        {
//            var response = await _authenticationService.RegisterUserAsync(request);
//            return Ok(response);
//        }

//        [HttpPost("Login")]
//        public async Task<IActionResult> Login([FromBody] LoginDto request)
//        {
//            _logger.LogInformation($"User attempting to log in with Identifier: {request.Identifier}");
//            var result = await _authenticationService.LoginAsync(request);
//            return Ok(result);
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using UserManagementWebAPI.DTO_s.Auth;
using UserManagementWebAPI.Filters;
using UserManagementWebAPI.Services.Auth.Interfaces;

namespace UserManagementWebAPI.Controllers.Auth
{
    /// <summary>
    /// Provides authentication-related API endpoints for user registration and login.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    public class AuthController : ControllerBase
    {
        private readonly IUserAuthService _authenticationService;
        private readonly ILogger<AuthController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">
        /// Service responsible for handling user authentication and registration operations.
        /// </param>
        /// <param name="logger">
        /// Logger used to record authentication-related information and events.
        /// </param>
        public AuthController(
            IUserAuthService authService,
            ILogger<AuthController> logger)
        {
            _authenticationService = authService;
            _logger = logger;
        }

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="request">
        /// Contains the information required to create a new user account.
        /// </param>
        /// <returns>
        /// Returns an <see cref="IActionResult"/> containing the registration result.
        /// </returns>
        /// <response code="200">
        /// User registration was processed successfully.
        /// </response>
        /// <response code="400">
        /// The supplied registration data is invalid.
        /// </response>
        /// <response code="409">
        /// A user with the supplied information already exists.
        /// </response>
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(
            [FromBody] RegisterUserDto request)
        {
            var response =
                await _authenticationService.RegisterUserAsync(request);

            return Ok(response);
        }

        /// <summary>
        /// Authenticates a user using the supplied credentials.
        /// </summary>
        /// <param name="request">
        /// Contains the user's login identifier and password.
        /// </param>
        /// <returns>
        /// Returns an <see cref="IActionResult"/> containing the authentication result,
        /// including the authentication token when login is successful.
        /// </returns>
        /// <response code="200">
        /// User authentication was successful.
        /// </response>
        /// <response code="400">
        /// The supplied login data is invalid.
        /// </response>
        /// <response code="401">
        /// Authentication failed because the supplied credentials are invalid.
        /// </response>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            _logger.LogInformation("User attempting to log in with Identifier: {Identifier}", request.Identifier);
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }
    }
}
