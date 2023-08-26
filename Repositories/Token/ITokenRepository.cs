using Microsoft.AspNetCore.Identity;

namespace EDIWalks.Repositories.Token
{
    public interface ITokenRepository
    {
        string GetJWTToken(IdentityUser user, List<string> roles);
    }
}
