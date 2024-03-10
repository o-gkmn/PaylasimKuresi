using Core.Interfaces;
using Identity.Models;
using Identity.Services;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs;
using Models.Errors;

namespace Core.Services;

public class TokenManager : ITokenManager
{
    private readonly PersonaManager _personaManager;

    public TokenManager(PersonaManager personaManager)
    {
        _personaManager = personaManager;
        _tokenManagerFactory = new TokenManagerFactory();
        AccessTokenManager = _tokenManagerFactory.CreateAccessTokenManager();
        RefreshTokenManager = _tokenManagerFactory.CreateRefreshTokenManager();
    }

    private AccessTokenManager AccessTokenManager { get; set; }
    private RefreshTokenManager RefreshTokenManager { get; set; }

    public TokenValidationParameters GetTokenValidationParameters() => AccessTokenManager.GeTokenValidationParameters();
    public async Task<Token> GenerateAccessToken(string refreshToken)
    {
        var isRefreshTokenValid = RefreshTokenManager.ValidateToken(refreshToken);

        if (!isRefreshTokenValid) throw TokenError.InvalidToken;

        var principal = RefreshTokenManager.GetPrincipal(refreshToken);
        if (principal.Identity.Name == null) throw TokenError.InvalidToken;
        var userEntity = await _personaManager.FindUserByUserName(principal.Identity.Name);
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