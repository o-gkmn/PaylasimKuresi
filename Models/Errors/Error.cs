namespace Models.Errors;

public sealed record Error(string Code, string? Description = null)
{
    public static readonly Error None = new(string.Empty);
    public static implicit operator Result(Error error) => Result.Failure(error);
}

public class UserError
{
    public static readonly Error UserAlreadyExist = new Error("UserError.UserAlreadyExist", "This username cannot be used because it is already in use.");
    public static readonly Error UserNotFound = new Error("UserError.UserNotFound", "This user cannot be found. Wrong email or username");
    public static readonly Error WrongPassword = new Error("UserError.WrongPassword", "Password is not correct.");
}

public class ModelError
{
    public static readonly Error ModelNull = new Error(Code: "ModelError.ModelNull", "The given model was null!");
    public static readonly Error EmptyPassword = new Error("ModelError.EmptyPassword", "Password cannot be empty!");
    public static readonly Error EmptyUserName = new Error("ModelError.EmptyUserName", "Username cannot be empty!");

}