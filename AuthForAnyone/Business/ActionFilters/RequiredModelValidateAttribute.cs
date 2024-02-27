using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthenticationServiceApi.Business.ActionFilters
{
    public class RequiredModelValidateAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var count = context.ModelState.Count;
                var errors = new Dictionary<string, string[]>(count);
                foreach(var keyModelStatePair in context.ModelState) 
                { 
                    var key = keyModelStatePair.Key;
                    var modelErrors = keyModelStatePair.Value.Errors;

                    if(modelErrors is not null && modelErrors.Count > 0)
                    {
                        var errorMessages = modelErrors.Select(error => error.ErrorMessage).ToArray();
                        errors.Add(key, errorMessages);
                    }
                }

                var response = new
                {
                    Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.1",
                    StatusCode = StatusCodes.Status400BadRequest,
                    Result = errors
                };
                
                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
