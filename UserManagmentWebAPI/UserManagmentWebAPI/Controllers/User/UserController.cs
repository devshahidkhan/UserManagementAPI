using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.DTO_s.Users;
using UserManagementWebAPI.Services.Users.Interface;

namespace UserManagementWebAPI.Controllers.User
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto request)
        {
            var isSaved = await userService.CreateUserAsync(request);
            //return Ok(message);    

            //Proper Json response
            return Ok(new
            {
                message = isSaved
            });
        }

        [HttpGet("GetById/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPut("UpdateUser/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto request)
        {
            var isUpdate = await userService.UpdateUser(id, request);

            return Ok(new
            {
                message = isUpdate
            });
        }

        [HttpDelete("DeleteUser/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDelete = await userService.DeleteUserAsync(id);
            if (!isDelete)
            {
                return NotFound("User not found");
            }
            return Ok("User Delete Successfully!");
        }
    }
}
