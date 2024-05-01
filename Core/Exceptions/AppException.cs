using Microsoft.AspNetCore.Http;

namespace Core.Exceptions;

public class AppException : Exception
{
    // Status code
    public int StatusCode { get; set; }

    // Code
    public int Code { get; set; }

    // Telescoping constructor: default statusCode
    public AppException(int code, string message) : this(StatusCodes.Status400BadRequest, code, message)
    {
        
    }

    public AppException(int statusCode, int code, string message) : base(message)
    {
        StatusCode = statusCode;
        Code = code;
    }
}
