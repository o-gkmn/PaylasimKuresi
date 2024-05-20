using Microsoft.AspNetCore.Http;

namespace Models.Errors;

public static class CommunityError
{
    public static readonly Error CommunityNotCreated = new Error(StatusCodes.Status417ExpectationFailed,
        nameof(CommunityError.CommunityNotCreated),
        "Topluluk oluşturulurken bir hata oluştu.");
}
