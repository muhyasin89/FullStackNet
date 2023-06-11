﻿using Backend.DTOs;
using Backend.DTOs.Input;
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

        public Task<User?> GetUserById(Guid id);

        public UserDTO RecordCreatedUser(User user);

        public bool IsEmail(string username);

        public Task<User?> GetUserLogin(LoginDTOInput loginDTO);
    }
}
