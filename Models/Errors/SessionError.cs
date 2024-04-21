using Microsoft.AspNetCore.Http;

namespace Models.Errors
{
    public class SessionError
    {
        public static readonly Error SessionTimeExpired = new Error(StatusCodes.Status401Unauthorized, "SessionError.SessionTimeExpired", "Session time expired. Please sign in again.");
    }
}
