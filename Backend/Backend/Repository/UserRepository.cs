using Backend.Data;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Backend.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly AppAPIContext _context;
        public UserRepository(AppAPIContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
           await _context.Users.AddAsync(user);

            return user;
        }

        public async Task<List<User>?> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?>  GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByPhone(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phone);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserById(Guid Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public User RecordCreatedUser(User user)
        {
            user.CreatedBy = user.Id;
            _context.Entry(user).State = EntityState.Modified;

            return user;
        }
    }
}
