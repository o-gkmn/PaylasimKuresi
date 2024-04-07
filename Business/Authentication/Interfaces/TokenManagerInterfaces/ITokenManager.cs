using Models.DTOs.TokenDTOs;
using Models.Entities;

namespace Business.Authentication.Interfaces.TokenManagerInterfaces;

public interface ITokenManager
{
    Task<TokenDto> GenerateAccessToken(string refreshToken);
    TokenDto GenerateRefreshToken(User userEntity);
    bool ValidateToken(TokenDto tokenDto);
    Task<User> FindUserByRefreshToken(string refreshToken);
}
