using API.Entities;

namespace API.Interfaces
{
    public interface ITokenService {
        string CreateToken(AppUser user); // CreateToken should generate a JWT token string for the given user.
    }
}