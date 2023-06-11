using Backend.Entities;

namespace Backend.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetByUsername(string username);
        Task<User?> GetByEmail(string email);

        Task<User?> GetByPhone(string phone);

        Task<User> AddUser(User user);
    }
}
