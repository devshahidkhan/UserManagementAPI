using Microsoft.AspNetCore.Mvc;
using UserManagementWebAPI.DTO_s.Auth;
using UserManagementWebAPI.Filters;
using UserManagementWebAPI.Services.Auth.Interfaces;
using UserManagementWebAPI.Services.Users.Interface;


namespace UserManagementWebAPI.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    public class AuthController : ControllerBase
    {
        private readonly IUserAuthService _authenticationService;
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _user;

        public AuthController(IUserAuthService authenticationService, ILogger<AuthController> logger, IUserService user)
        {
            _authenticationService = authenticationService;
            _logger = logger;
            _user = user;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto request)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //Use Filter

            var response = await _authenticationService.RegisterUserAsync(request);
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            _logger.LogInformation($"User attempting to log in with Identifier: {request.Identifier}");
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }
    }
}
