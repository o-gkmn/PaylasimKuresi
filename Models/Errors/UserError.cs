using Microsoft.AspNetCore.Http;

namespace Models.Errors
{
    public class UserError
    {
        public static readonly Error UserAlreadyExist = new Error(StatusCodes.Status400BadRequest, "UserError.UserAlreadyExist", "This username cannot be used because it is already in use.");
        public static readonly Error UserNotFound = new Error(StatusCodes.Status400BadRequest, "UserError.UserNotFound", "This user cannot be found. Wrong email or username");
        public static readonly Error WrongPassword = new Error(StatusCodes.Status400BadRequest, "UserError.WrongPassword", "Password is not correct.");
        public static readonly Error PasswordDoNotMatch = new Error(StatusCodes.Status400BadRequest, "UserError.PasswordDoNotMatch", "Şifreler eşeleşmiyor");
    }
}
