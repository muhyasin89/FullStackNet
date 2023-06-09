namespace Backend.Data.Model
{
    public class User_Auth_Activity
    {

        public int UserId { get; set; }
        public User? User { get; set; }

        public int AuthActivityId { get; set; }

        public AuthActivity? AuthActivity { get; set; }
    }
}
