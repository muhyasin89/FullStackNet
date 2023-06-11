namespace Backend.DTOs.Response
{
    public class UsersResponse
    {
        public int CodeStatus { get; set; }

        public List<UserDTO>? Data { get; set; }

        public string Message { get; set; } = "Loaded Record Success";
    }
}
