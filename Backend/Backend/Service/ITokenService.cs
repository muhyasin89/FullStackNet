using Backend.Entities;

namespace Backend.Service
{
    public interface ITokenService
    {
        string CreateToken(User? user, DateTime expired);
    }
}
