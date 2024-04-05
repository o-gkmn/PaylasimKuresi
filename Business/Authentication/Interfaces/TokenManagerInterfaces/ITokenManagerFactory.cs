using Core.Services;

namespace Core.Interfaces;

public interface ITokenManagerFactory
{
    public AccessTokenManager CreateAccessTokenManager();
    public RefreshTokenManager CreateRefreshTokenManager();
}