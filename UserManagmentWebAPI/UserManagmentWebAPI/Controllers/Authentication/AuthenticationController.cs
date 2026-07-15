using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagmentWebAPI.DTO_s.Authentication;
using UserManagmentWebAPI.Services.Interfaces;

namespace UserManagmentWebAPI.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _authenticationService;

        public AuthenticationController(IUserAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest request) 
        {
            var response = await _authenticationService.RegisterUserAsync(request);
            return Ok(response);
        }
    }
}
