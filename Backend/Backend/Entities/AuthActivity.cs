using Backend.Data;
using Backend.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public class AuthActivity
    {
        [Key]
        public Guid Id { get; set; }
        public AuthCategory AuthCategory { get; set; }

        public List<User_Auth_Activity>? User_Auth_Activity { get; set; }
    }
}
