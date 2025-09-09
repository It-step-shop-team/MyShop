using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.API.Extensions;

public static class ErrorOrExtensions
{
    public static IActionResult GetIActionResult<T>(this ErrorOr<T> errorOr)
    {
        if (!errorOr.IsError)
            return new OkObjectResult(errorOr.Value);
        
        var firstError = errorOr.FirstError;

        return firstError.Type switch
        {
            ErrorType.NotFound => new OkObjectResult(firstError),
            ErrorType.Validation => new BadRequestObjectResult(firstError),
            ErrorType.Unauthorized => new UnauthorizedObjectResult(firstError),
            _ => new ConflictObjectResult(firstError)
        };
    }
}