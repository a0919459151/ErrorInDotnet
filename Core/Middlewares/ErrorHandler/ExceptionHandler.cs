using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Core.Middlewares.ErrorHandler;

public static class ExceptionHandler
{
    // Handle App Exception
    public static async Task HandleAppException(HttpContext context, AppException exception)
    {
        Result result;
        var response = context.Response;

        response.ContentType = "application/json";

        // Custom Error Codes
        if (exception.Code.Length > 3)
        {
            var statusCode = exception.Code.Substring(0, 3);

            (response.StatusCode, result) = statusCode switch
            {
                CommonErrorCode.BadRequest => ((int)HttpStatusCode.BadRequest, Result.BadRequest(exception.Message)),
                CommonErrorCode.Unauthorized => ((int)HttpStatusCode.Unauthorized, Result.Unauthorized(exception.Message)),
                CommonErrorCode.Forbidden => ((int)HttpStatusCode.Forbidden, Result.Forbidden(exception.Message)),
                CommonErrorCode.NotFound => ((int)HttpStatusCode.NotFound, Result.NotFound(exception.Message)),
                CommonErrorCode.ServerError => ((int)HttpStatusCode.InternalServerError, Result.InternalServerError(exception.Message)),
                // No match, return BadRequest
                _ => ((int)HttpStatusCode.InternalServerError, Result.BadRequest(exception.Message))  
            };
        }
        // Common Error Codes
        else
        {
            (response.StatusCode, result) = exception.Code switch
            {
                CommonErrorCode.BadRequest => ((int)HttpStatusCode.BadRequest, Result.BadRequest(exception.Message)),
                CommonErrorCode.Unauthorized => ((int)HttpStatusCode.Unauthorized, Result.Unauthorized(exception.Message)),
                CommonErrorCode.Forbidden => ((int)HttpStatusCode.Forbidden, Result.Forbidden(exception.Message)),
                CommonErrorCode.NotFound => ((int)HttpStatusCode.NotFound, Result.NotFound(exception.Message)),
                CommonErrorCode.ServerError => ((int)HttpStatusCode.InternalServerError, Result.InternalServerError(exception.Message)),
                // No match, return InternalServerError
                _ => ((int)HttpStatusCode.InternalServerError, Result.InternalServerError(exception.Message))  
            };
        }

        await response.WriteAsync(JsonSerializer.Serialize(result));
    }

    // Handle Server Error Exception
    public static async Task HandleServerErrorException(HttpContext context, Exception exception)
    {
        var response = context.Response;

        response.ContentType = "application/json";
        response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = Result.InternalServerError(exception.Message);

        await response.WriteAsync(JsonSerializer.Serialize(result));
    }
}
