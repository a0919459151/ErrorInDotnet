using Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Core.Middlewares.ErrorHandler;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _ = ex switch
            {
                AppException appException => ExceptionHandler.HandleAppException(context, appException),
                _ => ExceptionHandler.HandleServerErrorException(context, ex)
            };
        }
    }
}
