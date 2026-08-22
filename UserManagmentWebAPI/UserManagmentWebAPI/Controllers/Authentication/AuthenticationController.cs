using Microsoft.AspNetCore.Mvc;
using UserManagementWebAPI.DTO_s.Authentication;
using UserManagementWebAPI.DTO_s.Users;
using UserManagementWebAPI.Filters;
using UserManagementWebAPI.Services.Auth.Interfaces;
using UserManagementWebAPI.Services.Users.Interface;


namespace UserManagementWebAPI.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserService _user;

        public AuthenticationController(IUserAuthenticationService authenticationService, ILogger<AuthenticationController> logger, IUserService user)
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
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation($"User attempting to log in with Identifier: {request.Identifier}");
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }
    }
}
