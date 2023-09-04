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

        public string Description { get; set; } = String.Empty;

        public List<UserAuthActivity>? UserAuthActivity { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
