using Core.Middlewares.ErrorHandler;
using Microsoft.AspNetCore.Builder;

namespace Middleware.Middlewares;

public static class ErrorHandlerMiddlewareExtension
{
    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}