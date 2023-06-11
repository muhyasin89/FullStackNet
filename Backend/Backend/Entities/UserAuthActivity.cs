namespace Backend.Entities
{
    public class UserAuthActivity
    {

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid AuthActivityId { get; set; }

        public AuthActivity? AuthActivity { get; set; }
    }
}
