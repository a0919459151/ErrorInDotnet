using Microsoft.AspNetCore.Http;

namespace Core.Middlewares.ErrorHandler;

#region Common error code
public static class CommonErrorCode
{
    public static int Success => StatusCodes.Status200OK;
    public static int BadRequest => StatusCodes.Status400BadRequest;
    public static int Unauthorized => StatusCodes.Status401Unauthorized;
    public static int Forbidden => StatusCodes.Status403Forbidden;
    public static int NotFound => StatusCodes.Status404NotFound;
    public static int ServerError => StatusCodes.Status500InternalServerError;
}
#endregion

#region Custom error code

#endregion
