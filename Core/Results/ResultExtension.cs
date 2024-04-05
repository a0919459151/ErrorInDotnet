using Microsoft.AspNetCore.Http;

namespace Core.Results;

public static class CommonResultExtension
{
    // Success method
    public static Result Success(this Result result)
    {
        result.IsSuccess = true;
        result.Code = StatusCodes.Status200OK;
        result.Message = "Success";
        return result;
    }

    // BadRequest method
    public static Result BadRequest(this Result result, string message)
    {
        result.IsSuccess = false;
        result.Code = StatusCodes.Status400BadRequest;
        result.Message = message;
        return result;
    }

    // Unauthorized method
    public static Result Unauthorized(this Result result, string message)
    {
        result.IsSuccess = false;
        result.Code = StatusCodes.Status401Unauthorized;
        result.Message = message;
        return result;
    }

    // Forbidden method
    public static Result Forbidden(this Result result, string message)
    {
        result.IsSuccess = false;
        result.Code = StatusCodes.Status403Forbidden;
        result.Message = message;
        return result;
    }

    // NotFound method
    public static Result NotFound(this Result result, string message)
    {
        result.IsSuccess = false;
        result.Code = StatusCodes.Status404NotFound;
        result.Message = message;
        return result;
    }

    // InternalServerError method
    public static Result ServerError(this Result result, string message)
    {
        result.IsSuccess = false;
        result.Code = 500;
        result.Message = message;
        return result;
    }
}

public static class CustomResultExtension
{
    // BadRequest method
    public static Result Error(this Result result, int code, string message)
    {
        result.IsSuccess = false;
        result.Code = code;
        result.Message = message;
        return result;
    }
}
