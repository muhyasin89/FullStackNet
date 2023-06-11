using Backend.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Backend.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByUsername(string username);
        Task<User?> GetByEmail(string email);

        Task<User?> GetByPhone(string phone);

        Task<User> AddUser(User user);

        Task<User?> GetUserById(Guid Id);

        Task<List<User>?> GetAllUsers();

        Task<bool> SaveUser(User user, ModelStateDictionary modelState);

        User RecordCreatedUser(User user);
    }
}
