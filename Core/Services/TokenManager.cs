using Core.Interfaces;
using Identity.Interfaces;
using Identity.Models;
using Models.DTOs.TokenDTOs;
using Models.Errors;

namespace Core.Services;

public class TokenManager : ITokenManager
{
    private readonly IPersonaManager _personaManager;

    public TokenManager(IPersonaManager personaManager)
    {
        _personaManager = personaManager;
        _tokenManagerFactory = new TokenManagerFactory();
        AccessTokenManager = _tokenManagerFactory.CreateAccessTokenManager();
        RefreshTokenManager = _tokenManagerFactory.CreateRefreshTokenManager();
    }

    private AccessTokenManager AccessTokenManager { get; set; }
    private RefreshTokenManager RefreshTokenManager { get; set; }

    public async Task<TokenDto> GenerateAccessToken(string refreshToken)
    {
        var isRefreshTokenValid = RefreshTokenManager.ValidateToken(refreshToken);

        if (!isRefreshTokenValid) throw TokenError.InvalidToken;

        var userEntity = await FindUserByRefreshToken(refreshToken);
        var accessToken = AccessTokenManager.GenerateToken(userEntity);

        return new TokenDto(accessToken, refreshToken);
    }

    public TokenDto GenerateRefreshToken(UserEntity userEntity)
    {
        var refreshToken = RefreshTokenManager.GenerateToken(userEntity);
        var accessToken = AccessTokenManager.GenerateToken(userEntity);

        return new TokenDto(accessToken, refreshToken);
    }

    public bool ValidateToken(TokenDto tokenDto)
    {
        var isAccessTokenValid = AccessTokenManager.ValidateToken(tokenDto.AccessToken);
        var isRefreshTokenValid = RefreshTokenManager.ValidateToken(tokenDto.RefreshToken);

        if (isAccessTokenValid && !isRefreshTokenValid)
        {
            throw TokenError.RefreshTokenExpired;
        }

        if (!isAccessTokenValid && isRefreshTokenValid)
        {
            throw TokenError.AccessTokenExpired;
        }

        if (isAccessTokenValid && isRefreshTokenValid)
        {
            return true;
        }

        return false;
    }

    public async Task<UserEntity> FindUserByRefreshToken(string refreshToken)
    {
        var principal = RefreshTokenManager.GetPrincipal(refreshToken);
        if (principal.Identity.Name == null) throw TokenError.InvalidToken;
        var user = await _personaManager.FindUserByUserNameAsync(principal.Identity.Name);

        return user;
    }

    private ITokenManagerFactory _tokenManagerFactory;
}