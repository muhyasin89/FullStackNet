using Backend.Data;
using Backend.DTOs;
using Backend.DTOs.Input;
using Backend.Entities;
using Backend.Repository;
using Backend.Service;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Backend.Migrations
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> AddUser(User user)
        {
            var result = await _userRepository.AddUser(user);

            return ChangeUserToDTOService(result);
        }


        public UserDTO ChangeUserToDTOService(User user) {
            var userDto = new UserDTO
            {
                Username = user.Username,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ProfilePicture = user.Avatar,
                DateOfBirth = user.DOB,
                isLocked = user.isLocked,
                isDelete = user.IsDeleted
            };


            return userDto;
        }

        public async Task<bool> EmailExists(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return user != null;
        }

        public async Task<bool> PhoneExists(string phone)
        {
            var user = await _userRepository.GetByPhone(phone);
            return user != null;
        }


        public async Task<bool> UserNameExist(string username)
        {
            var user = await _userRepository.GetByUsername(username);
            return user != null;
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _userRepository.GetUserById(id);
        }

        public  UserDTO RecordCreatedUser(User user)
        {
            var result = _userRepository.RecordCreatedUser(user);

            return ChangeUserToDTOService(result);
        }

        public bool IsEmail(string username)
        {
            // Email pattern regular expression
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Check if the input matches the email pattern
            if (Regex.IsMatch(username, pattern))
            {
                return true;  // It's an email
            }
            else
            {
                return false; // It's a regular string
            }
        }

        public async Task<User?> GetUserLogin(LoginDTOInput loginDTO)
        {
            User? user = null;
            if (IsEmail(loginDTO.Username!))
            {
                user = await _userRepository.GetByEmail(loginDTO.Username!);
            }
            else
            {
                user = await _userRepository.GetByUsername(loginDTO.Username!);
            }

            return user;
        }

        public async Task<UserDTO?> GetUser(Guid id)
        {
            User? user = await GetUserById(id);

            if(user == null) { return null; }

            return ChangeUserToDTOService(user);
        }

        public async Task<List<UserDTO>?> GetUsers()
        {
            List<User>? users = await _userRepository.GetAllUsers();

            if(users == null) { return null; }
            List<UserDTO>? result = null;
            foreach (var user in users)
            {
                result?.Add(ChangeUserToDTOService(user!));
            }

            return result;
        }
    }
}
