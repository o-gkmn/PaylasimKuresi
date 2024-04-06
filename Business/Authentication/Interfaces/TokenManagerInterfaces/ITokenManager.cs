using Models.DTOs.TokenDTOs;
using Models.Entities;

namespace Business.Authentication.Interfaces.TokenManagerInterfaces;

public interface ITokenManager
{
    Task<TokenDto> GenerateAccessToken(string refreshToken);
    TokenDto GenerateRefreshToken(UserEntity userEntity);
    bool ValidateToken(TokenDto tokenDto);
    Task<UserEntity> FindUserByRefreshToken(string refreshToken);
}