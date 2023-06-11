using Backend.DTOs.Input;
using Backend.DTOs.Response;
using Backend.Entities;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Controllers
{
    public class AuthController : BaseAPIController
    {

        private readonly IUserService _userService;

        public AuthController( IUserService userDTOService)
        {
            _userService = userDTOService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterDTO registerDTO)
        {

            RegisterResponse results = new RegisterResponse
            {
                CodeStatus = 200,
                Message = "Ok"
            };

            if (await _userService.UserNameExist(registerDTO.Username!.ToString()))
            {

                results.CodeStatus = 400;
                results.Message = "User Already Exist";


                return Ok(results);
            }

            if (await _userService.EmailExists(registerDTO.Username.ToString()))
            {



                results.CodeStatus = 400;
                results.Message = "Email Already Exist";

                return Ok(results);
            }


            if (await _userService.PhoneExists(registerDTO.Username.ToString()))
            {

                results.CodeStatus = 400;
                results.Message = "PhoneNumber Already Exist";

                return Ok(results);
            }

            using var hmac = new HMACSHA512();

            var user = new User
            {
                Username = registerDTO.Username!,
                Email = registerDTO.Email!,
                Name = registerDTO.Name!,
                PhoneNumber = registerDTO.PhoneNumber!,
                DOB = registerDTO.DOB,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password!)),
                PasswordSalt = hmac.Key
            };


            results.Data = _userService.ChangeUserToDTOService(user);
            results.Message = "Record Success";

            return Ok(results);
        }
    }
}
