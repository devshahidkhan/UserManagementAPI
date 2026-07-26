using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementWebAPI.Filters;
using UserManagementWebAPI.Services.Interfaces;
using UserManagementWebAPI.DTO_s.Authentication;


namespace UserManagementWebAPI.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IUserAuthenticationService authenticationService, ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto request) 
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
        public async Task<IActionResult>Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation($"User attempting to log in with Identifier: {request.Identifier}");
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }
    }
}
