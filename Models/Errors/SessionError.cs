using Microsoft.AspNetCore.Http;

namespace Models.Errors
{
    public class SessionError
    {
        public static readonly Error SessionTimeExpired = new Error(StatusCodes.Status401Unauthorized, "SessionError.SessionTimeExpired", "Session time expired. Please sign in again.");
        public static readonly Error UserNotAuthenticated = new Error(StatusCodes.Status401Unauthorized, nameof(SessionError) + "." + nameof(UserNotAuthenticated), "Kullanıcının kimliği doğrulanmadı.");
    }
}
