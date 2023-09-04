namespace Backend.DTOs.Response
{
    public class RegisterResponse
    {

        public int CodeStatus { get; set; }

        public UserDTO? Data { get; set; }

        public string Message { get; set; } = "Loaded Record Success";
    }
}
