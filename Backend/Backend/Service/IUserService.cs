using Backend.DTOs.Response;
using Backend.Entities;

namespace Backend.Service
{
    public interface IUserService
    {
        public UserDTO ChangeUserToDTOService(User user);
        public Task<bool> UserNameExist(string username);
        public Task<bool> PhoneExists(string phone);

        public Task<bool> EmailExists(string email);

        public Task<UserDTO> AddUser(User user);
    }
}
