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
                // Handle the known bad request exception
                AppException appException => ExceptionHandler.HandleAppException(context, appException),
                // Handel the known server error exception
                ServerErrorException serverErrorException => ExceptionHandler.HandleServerErrorException(context, serverErrorException),
                // Handle the unknown exception
                _ => ExceptionHandler.HandleServerErrorException(context, ex)
            };
        }
    }
}
