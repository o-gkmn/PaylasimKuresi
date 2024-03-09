namespace Models.DTOs;

public record Token(string accessToken, string refreshToken)
{
    public string AccessToken { get; init; } = accessToken;
    public string RefreshToken { get; init; } = refreshToken;
}