using Microsoft.AspNetCore.Builder;

namespace Core.Middlewares.ErrorHandler;

public static class ErrorHandlerMiddlewareExtension
{
    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}