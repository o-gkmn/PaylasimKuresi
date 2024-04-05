using Identity.Models;
using Models.DTOs.TokenDTOs;

namespace Core.Interfaces;

public interface ITokenManager
{
    Task<TokenDto> GenerateAccessToken(string refreshToken);
    TokenDto GenerateRefreshToken(UserEntity userEntity);
    bool ValidateToken(TokenDto tokenDto);
    Task<UserEntity> FindUserByRefreshToken(string refreshToken);
}