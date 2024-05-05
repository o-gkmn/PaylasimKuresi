using Microsoft.AspNetCore.Http;

namespace Models.Errors
{
    public class ModelError
    {
        public static readonly Error ModelNull = new Error(StatusCodes.Status400BadRequest, "ModelError.ModelNull", "The given model was null!");
        public static readonly Error EmptyPassword = new Error(StatusCodes.Status400BadRequest, "ModelError.EmptyPassword", "Password cannot be empty!");
        public static readonly Error EmptyEmail = new Error(StatusCodes.Status400BadRequest, "ModelError.EmptyEmail", "Email boş olamaz");
    }
}
