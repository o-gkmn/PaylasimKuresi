using Microsoft.AspNetCore.Http;

namespace Models.Errors;

public sealed class Error(int code, string description) : Exception(description)
{
    public int Code { get; init; } = code;
    public string Description { get; init; } = description;
}

public class UserError
{
    public static readonly Error UserAlreadyExist = new Error(StatusCodes.Status400BadRequest, "This username cannot be used because it is already in use.");
    public static readonly Error UserNotFound = new Error(StatusCodes.Status400BadRequest, "This user cannot be found. Wrong email or username");
    public static readonly Error WrongPassword = new Error(StatusCodes.Status400BadRequest, "Password is not correct.");
}

public class ModelError
{
    public static readonly Error ModelNull = new Error(StatusCodes.Status400BadRequest, "The given model was null!");
    public static readonly Error EmptyPassword = new Error(StatusCodes.Status400BadRequest, "Password cannot be empty!");
    public static readonly Error EmptyUserName = new Error(StatusCodes.Status400BadRequest, "Username cannot be empty!");

}

public class TokenError
{
    public static readonly Error InvalidToken = new Error(StatusCodes.Status400BadRequest, "The given token is invalid. Please login again.")
}