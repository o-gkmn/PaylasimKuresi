using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.TokenDTOs;
using Models.Errors;
using Newtonsoft.Json;

namespace AuthForAnyone.Controllers;

[ApiController]
[Route("api/token")]
public class TokenController(ITokenManager tokenManager) : ControllerBase
{
    private readonly ITokenManager _tokenManager = tokenManager;

    [HttpPost("generate-access-token")]
    public async Task<IActionResult> CreateAccessToken(TokenDto tokenDto)
    {
        var token = await _tokenManager.GenerateAccessToken(tokenDto.RefreshToken);
        return Ok(token);
    }

    [HttpPost("generate-refresh-token")]
    public async Task<IActionResult> GenerateRefreshToken(string refreshToken)
    {
        var user = await _tokenManager.FindUserByRefreshToken(refreshToken);
        if (user == null) throw TokenError.InvalidToken;
        var token = _tokenManager.GenerateRefreshToken(user);
        return Ok(token);
    }

    [HttpPost("validate-token")]
    public IActionResult ValidateToken(TokenDto tokenDto)
    {
        var result = _tokenManager.ValidateToken(tokenDto);
        if (result) return Ok();
        throw SessionError.SessionTimeExpired;
    }
}