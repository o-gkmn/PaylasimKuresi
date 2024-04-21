using Microsoft.AspNetCore.Http;

namespace Models.Errors
{
    public class ServerError
    {
        public static readonly Error ServerNotResponding = new Error(StatusCodes.Status503ServiceUnavailable, "ServerError.ServerNotResponding", "Server not responding.");
    }
}
