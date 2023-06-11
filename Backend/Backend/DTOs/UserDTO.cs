using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class UserDTO
    {

        public Guid Id { get; set; }


        public string Username { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string ProfilePicture { get; set; } = string.Empty;

        public bool isLocked { get; set; } = false;

        public bool isDelete { get; set; }


        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
