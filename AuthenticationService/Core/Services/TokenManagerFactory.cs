using Core.Interfaces;

namespace Core.Services;

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