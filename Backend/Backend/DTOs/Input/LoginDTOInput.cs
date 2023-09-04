using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Input
{
    public class LoginDTOInput
    {

        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
