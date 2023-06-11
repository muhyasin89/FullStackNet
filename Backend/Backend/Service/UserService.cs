using Backend.Data;
using Backend.DTOs.Response;
using Backend.Entities;
using Backend.Repository;
using Backend.Service;
using System.Numerics;

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
    }
}
