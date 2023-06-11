using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Input
{
    public class LoginDTO
    {

        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
