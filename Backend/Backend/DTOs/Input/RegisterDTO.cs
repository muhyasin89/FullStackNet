using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Input
{
    public class RegisterDTO
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
}
