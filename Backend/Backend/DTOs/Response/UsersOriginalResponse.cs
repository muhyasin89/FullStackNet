using Backend.Entities;

namespace Backend.DTOs.Response
{
    public class UsersOriginalResponse
    {
        public int CodeStatus { get; set; }

        public List<User>? Data { get; set; }

        public string Message { get; set; } = "Loaded Record Success";
    }
}
