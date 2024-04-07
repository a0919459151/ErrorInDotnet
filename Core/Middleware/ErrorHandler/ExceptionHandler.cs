using Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Core.Middlewares.ErrorHandler;

public static class ExceptionHandler
{
    // Handle App Exception
    public static async Task HandleAppException(HttpContext context, AppException exception)
    {
        var response = context.Response;

        response.ContentType = "application/json";
        response.StatusCode = (int)HttpStatusCode.BadRequest;
        
        var result = new Result().BadRequest(exception.Message);

        await response.WriteAsync(JsonSerializer.Serialize(result));
    }

    // Handle Server Error Exception
    public static async Task HandleServerErrorException(HttpContext context, Exception exception)
    {
        var response = context.Response;

        response.ContentType = "application/json";
        response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = new Result().ServerError(exception.Message);

        await response.WriteAsync(JsonSerializer.Serialize(result));
    }
}
