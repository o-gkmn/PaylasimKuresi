using Business.Authentication.Interfaces.TokenManagerInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models.DTOs.TokenDTOs;
using Models.Errors;

namespace PaylasimKuresi.Filters;

public class UserAuthenticationFilter(ITokenManager tokenManager) : Attribute, IAsyncAuthorizationFilter
{
    private readonly ITokenManager _tokenManager = tokenManager;

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            if (UserIsAuthenticated(context))
            {
                return;
            }

            context.Result = new UnauthorizedResult();
            return;
        }
        catch (Error ex)
        {
            var oldToken = ExtractTokenFromHeaders(context);

            if (ex.Code == TokenError.AccessTokenExpired.Code &&
                ex.Description == TokenError.AccessTokenExpired.Description)
            {
                var newToken = await _tokenManager.GenerateAccessToken(oldToken.RefreshToken);

                AssignNewTokenToHeader(context, newToken);
            }

            if (ex.Code == TokenError.RefreshTokenExpired.Code &&
                ex.Description == TokenError.RefreshTokenExpired.Description)
            {
                var user = await _tokenManager.FindUserByRefreshToken(oldToken.RefreshToken);
                if (user == null) throw TokenError.InvalidToken;

                var newToken = _tokenManager.GenerateRefreshToken(user);
                AssignNewTokenToHeader(context, newToken);
            }
        }
    }

    private bool UserIsAuthenticated(AuthorizationFilterContext context)
    {
        var token = ExtractTokenFromHeaders(context);
        var result = _tokenManager.ValidateToken(token);
        return result;
    }

    private TokenDto ExtractTokenFromHeaders(AuthorizationFilterContext context)
    {
        var accessToken = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var refreshToken = context.HttpContext.Request.Headers["Refresh-Token"].ToString();

        if (accessToken == string.Empty || refreshToken == string.Empty)
        {
            throw TokenError.MissingToken;
        }

        return new TokenDto(accessToken, refreshToken);
    }

    private void AssignNewTokenToHeader(AuthorizationFilterContext context, TokenDto tokenDto)
    {
        context.HttpContext.Response.Headers["Authorization"] = "Bearer " + tokenDto.AccessToken;
        context.HttpContext.Response.Headers["Refresh-Token"] = tokenDto.RefreshToken;
    }
}
