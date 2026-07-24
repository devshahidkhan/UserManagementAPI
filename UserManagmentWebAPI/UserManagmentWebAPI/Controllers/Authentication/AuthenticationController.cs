using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementWebAPI.Filters;
using UserManagementWebAPI.Services.Interfaces;
using UserManagmentWebAPI.DTO_s.Authentication;
using UserManagmentWebAPI.Services.Interfaces;

namespace UserManagmentWebAPI.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _authenticationService;


        public AuthenticationController(IUserAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

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
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }
    }
}
