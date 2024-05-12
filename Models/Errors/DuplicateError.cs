using Microsoft.AspNetCore.Http;

namespace Models.Errors;

public class DuplicateError
{
    public static readonly Error PostAlreadyLiked = new Error(StatusCodes.Status409Conflict, nameof(DuplicateError.PostAlreadyLiked), "Kullanıcı gönderiyi zaten beğendi.");
}
