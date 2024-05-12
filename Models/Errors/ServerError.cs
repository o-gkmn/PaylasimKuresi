using Microsoft.AspNetCore.Http;

namespace Models.Errors
{
    public class ServerError
    {
        public static readonly Error ServerNotResponding = new Error(StatusCodes.Status503ServiceUnavailable, "ServerError.ServerNotResponding", "Server not responding.");
        public static readonly Error HttpContextUnavailable = new Error(StatusCodes.Status500InternalServerError, nameof(ServerError.HttpContextUnavailable), "HttpContext mevcut değil.");
    }
}
