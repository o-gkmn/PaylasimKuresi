using Core.Abstract;
using Identity.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Services;

public class AccessTokenManager : TokenManagerBase
{
    public new string GenerateToken(UserEntity userEntity) => base.GenerateToken(userEntity);
    public new bool ValidateToken(string token) => base.ValidateToken(token);
    public new ClaimsPrincipal? GetPrincipal(string token) => base.GetPrincipal(token);
    public TokenValidationParameters GeTokenValidationParameters() => base.TokenValidationParameters;

    protected override SecurityToken GetTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = Configuration.GetSection("JWT");

        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["AccessTokenExpirationTime"])),
            signingCredentials: signingCredentials);

        return tokenOptions;
    }

    protected override List<Claim> GetClaims(UserEntity userEntity)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, userEntity.UserName),
        };

        return claims;
    }
}