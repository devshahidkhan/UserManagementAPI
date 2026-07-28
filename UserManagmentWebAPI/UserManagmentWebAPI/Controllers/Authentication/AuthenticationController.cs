using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Authentication;
using UserManagementWebAPI.DTO_s.Users;
using UserManagementWebAPI.Filters;
using UserManagementWebAPI.Services.Interfaces;
using UserManagementWebAPI.Services.Users.Implementation;
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
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation($"User attempting to log in with Identifier: {request.Identifier}");
            var result = await _authenticationService.LoginAsync(request);
            return Ok(result);
        }


        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUser()
        {
            var users = await _user.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _user.GetByIdAsync(id);
            return Ok(user);
        }


        [HttpPut("Update/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDto request)
        {
            var isUpdated = await _user.Update(id, request);

            if (!isUpdated)
            {
                return NotFound("User not found.");
            }

            return Ok("Updated Successfully.");
        }

        [HttpDelete("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _user.DeleteUserAsync(id);

            if (!isDeleted)
            {
                return NotFound("User not found.");
            }

            return Ok("Deleted Successfully.");
        }

    }
}
