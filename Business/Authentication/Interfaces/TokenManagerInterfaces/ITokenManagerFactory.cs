using Business.Authentication.Concrete.TokenService;

namespace Business.Authentication.Interfaces.TokenManagerInterfaces;

public interface ITokenManagerFactory
{
    public AccessTokenManager CreateAccessTokenManager();
    public RefreshTokenManager CreateRefreshTokenManager();
}