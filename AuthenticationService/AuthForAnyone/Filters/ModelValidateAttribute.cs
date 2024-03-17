using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthForAnyone.Filters
{
    public class ModelValidateAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var count = context.ModelState.Count;
                var errors = new Dictionary<string, string>(count);
                foreach (var keyModelStatePair in context.ModelState)
                {
                    var key = keyModelStatePair.Key;
                    var modelErrors = keyModelStatePair.Value.Errors;

                    if (modelErrors is not null && modelErrors.Count > 0)
                    {
                        var errorMessages = modelErrors.Select(error => error.ErrorMessage).AsQueryable();

                        foreach (var errorMessage in errorMessages)
                        {
                            errors.Add(key, errorMessage);
                        }
                    }
                }

                var response = new
                {
                    Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.1",
                    Title = "Bad Request",
                    StatusCode = StatusCodes.Status400BadRequest,
                    Detail = "You entered an invalid model.",
                    Errors = errors
                };

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
