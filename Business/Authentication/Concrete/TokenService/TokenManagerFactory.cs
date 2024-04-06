using Business.Authentication.Interfaces.TokenManagerInterfaces;

namespace Business.Authentication.Concrete.TokenService;

public class TokenManagerFactory : ITokenManagerFactory
{
    public AccessTokenManager CreateAccessTokenManager()
    {
        return new AccessTokenManager();
    }

    public RefreshTokenManager CreateRefreshTokenManager()
    {
        return new RefreshTokenManager();
    }
}