namespace AuthForAnyone.Models.Errors
{
    public class UserError
    {
        public static readonly Error UserAlreadyExist = new Error("UserError.UserAlreadyExist", "This username cannot be used because it is already in use.");
    }
}
