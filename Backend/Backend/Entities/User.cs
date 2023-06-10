using System.ComponentModel.DataAnnotations;
using Backend.Data;
using Backend.Entities;

namespace Backend.Entities
{
    public class User : IUpdateable
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DOB { get; set; }

        public string Avatar { get; set; } = string.Empty;

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public List<User_Auth_Activity>? User_Auth_Activity { get; set; }

        public bool isLocked { get; set; } = false; 



        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }

       
    }
}
