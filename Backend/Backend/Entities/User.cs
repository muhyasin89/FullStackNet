using System.ComponentModel.DataAnnotations;
using Backend.Data;
using Backend.Entities;

namespace Backend.Entities
{
    public class User : IUserUpdateable
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public string Avatar { get; set; } = string.Empty;

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        public List<User_Auth_Activity>? User_Auth_Activity { get; set; }

        public bool isLocked { get; set; } = false;


        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
