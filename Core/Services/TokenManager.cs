using Core.Interfaces;
using Identity.Models;
using Models.DTOs;
using Models.Errors;

namespace Core.Services;

public class TokenManager : ITokenManager
{
    public TokenManager()
    {
        _tokenManagerFactory = new TokenManagerFactory();
        AccessTokenManager = _tokenManagerFactory.CreateAccessTokenManager();
        RefreshTokenManager = _tokenManagerFactory.CreateRefreshTokenManager();
    }

    private AccessTokenManager AccessTokenManager { get; set; }
    private RefreshTokenManager RefreshTokenManager { get; set; }

    public Token GenerateAccessToken(string refreshToken)
    {
        var isRefreshTokenValid = RefreshTokenManager.ValidateToken(refreshToken);

        if (!isRefreshTokenValid) throw TokenError.InvalidToken;

        var principal = RefreshTokenManager.GetPrincipal(refreshToken);
        var userEntity = new UserEntity();
        var accessToken = AccessTokenManager.GenerateToken(userEntity);

        return new Token(accessToken, refreshToken);
    }

    public Token GenerateRefreshToken(UserEntity userEntity)
    {
        var refreshToken = RefreshTokenManager.GenerateToken(userEntity);
        var accessToken = AccessTokenManager.GenerateToken(userEntity);

        return new Token(accessToken, refreshToken);
    }

    private ITokenManagerFactory _tokenManagerFactory;
}