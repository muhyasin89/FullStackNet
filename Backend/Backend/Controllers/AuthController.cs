using Backend.Data;
using Backend.DTOs;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class AuthController : BaseAPIController
    {
        private readonly AppAPIContext _context;

        public AuthController(AppAPIContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDTO registerDTO)
        {
            if(await UserExist(registerDTO.Username))
            {
                return BadRequest("Username is Exist");
            }
        }
    }
}
