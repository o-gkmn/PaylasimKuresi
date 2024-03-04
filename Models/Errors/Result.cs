using Microsoft.AspNetCore.Http;

namespace Models.Errors;

public class Result
{
    public Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid Error", nameof(error));
        }

        IsSuccess = isSuccess;
        IsFailure = !isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure { get; }
    public Error Error { get; }
    
    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
}