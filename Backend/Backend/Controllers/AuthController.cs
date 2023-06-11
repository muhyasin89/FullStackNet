using Backend.DTOs.Input;
using Backend.DTOs.Response;
using Backend.Entities;
using Backend.Migrations;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Controllers
{
    public class AuthController : BaseAPIController
    {

        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userDTOService, ITokenService tokenService)
        {
            _userService = userDTOService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterDTOInput registerDTO)
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

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User? findUser = await _userService.GetUserById(user.Id);

            if (findUser == null)
            {
                return NotFound();
            }

            // set created time and id
            results.Data = _userService.RecordCreatedUser(user);
            results.Message = "Record Success";

            return Ok(results);
        }


        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> AuthLogin(LoginDTOInput loginDTO)
        {
            LoginResponse results = new LoginResponse
            {
                CodeStatus = 200,
                Message = "Ok"
            };

            var user = await _userService.GetUserLogin(loginDTO);
            if (user == null) return Unauthorized();

            using var hmac = new HMACSHA512(user.PasswordSalt!);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password!));

            for(int i=0; i< computedHash.Length; i++)
            {
                if (computedHash[i] != user!.PasswordHash![i]) return Unauthorized();
            }

            // if valid return token
            DateTime expiredTime = DateTime.Now.AddDays(7);
            String token = _tokenService.CreateToken(user, expiredTime);

            results.Token = token;
            results.Username = user.Username;
            results.ExpiredTime = expiredTime;

            return Ok(results);

        }

    }
}
