using Backend.DTOs;
using Backend.DTOs.Response;
using Backend.Entities;
using Backend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Authorize]
    public class UserController : BaseAPIController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersResponse>>> GetUsers()
        {
            UsersResponse results = new UsersResponse
            {
                Message = "Success retreive Record",
                Data = await _userService.GetUsers(),
                CodeStatus = 200
            };

            return Ok(results);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUser(Guid userId)
        {
            UserDTO? user = await _userService.GetUser(userId);
            if(user == null) { return NotFound(); }
            UserResponse results = new UserResponse
            {
                Message = "Success retreive Record",
                Data = user,
                CodeStatus = 200
            };

            return Ok(results);
        }
    }
}
