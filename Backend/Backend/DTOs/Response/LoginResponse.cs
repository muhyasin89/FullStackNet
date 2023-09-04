namespace Backend.DTOs.Response
{
    public class LoginResponse
    {
        public int CodeStatus { get; set; }

        public string Username { get; set; } = String.Empty;
        public DateTime ExpiredTime { get; set; }
        public string Token { get; set; } = String.Empty;

        public string Message { get; set; } = "Loaded Record Success";
    }
}
