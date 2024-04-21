using Microsoft.AspNetCore.Http;

namespace Models.Errors
{
    public class TokenError
    {
        public static readonly Error InvalidToken = new Error(StatusCodes.Status400BadRequest, "TokenError.InvalidToken", "The given token is invalid. Please login again.");
        public static readonly Error MissingToken = new Error(StatusCodes.Status400BadRequest, "TokenError.MissingToken", "Required token is not provided");
        public static readonly Error AccessTokenExpired = new Error(StatusCodes.Status401Unauthorized, "TokenError.AccessTokenExpired", "The access token was expired.");
        public static readonly Error RefreshTokenExpired = new Error(StatusCodes.Status401Unauthorized, "TokenError.RefreshTokenExpired", "The refresh token was expired.");
        public static readonly Error UnreadableToken = new Error(StatusCodes.Status401Unauthorized, "TokenError.UnreadableToken", "The given token is unreadable.");
        public static readonly Error FailedToGenerateToken = new Error(StatusCodes.Status500InternalServerError, "TokenError.FailedToGenerateToken", "New token generation failed.");
    }
}
