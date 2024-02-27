using AutoMapper.Internal.Mappers;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuthForAnyone.Models.Errors
{
    public class Result
    {
        public Result(bool isSuccess, List<Error>? errors)
        {
            if (isSuccess && errors != null ||
                !isSuccess && errors == null)
            {
                throw new ArgumentException("Invalid Error");
            }

            IsSuccess = isSuccess;
            Errors = errors;
        }

        public Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
                !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid Error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure { get; }
        public List<Error>? Errors { get; }
        public Error Error { get; }
        public static Result Success() => new(true, Error.None);
        public static Result Failure(List<Error> error) => new(false, error);
        public static Result Failure(Error error) => new(false, error);

        public object ToObject()
        {
            var errors = new Dictionary<string, string>();

            if (Errors is not null)
            {
                foreach (var error in Errors)
                {
                    errors.Add(error.Code, error.Description);
                }
            }
            else
            {
                errors.Add(Error.Code, Error.Description);
            }

            var responseForSingleError = new
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.1",
                Title = "Bad Request",
                StatusCode = StatusCodes.Status400BadRequest,
                Detail = "You entered an invalid model.",
                Errors = errors
            };

            return responseForSingleError;
        }
    }
}

