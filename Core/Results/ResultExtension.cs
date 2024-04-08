namespace Core.Results;

public static class CommonResultExtension
{
    // Success method
    public static Result Success(this Result result)
    {
        result.IsSuccess = true;
        result.Code = CommonErrorCode.Success;
        result.Message = "Success";
        return result;
    }
    public static Result<T> Success<T>(this Result<T> result)
    {
        result.IsSuccess = true;
        result.Code = CommonErrorCode.Success;
        result.Message = "Success";
        return result;
    }

    // BadRequest method
    public static Result BadRequest(this Result result, string message)
    {
        result.IsSuccess = false;
        result.Code = CommonErrorCode.BadRequest;
        result.Message = message;
        return result;
    }
    public static Result<T> BadRequest<T>(this Result<T> result, string message)
    {
        result.IsSuccess = false;
        result.Code = CommonErrorCode.BadRequest;
        result.Message = message;
        return result;
    }

    // Unauthorized method
    public static Result Unauthorized(this Result result, string message)
    {
        result.IsSuccess = false;
        result.Code = CommonErrorCode.Unauthorized;
        result.Message = message;
        return result;
    }
    public static Result<T> Unauthorized<T>(this Result<T> result, string message)
    {
        result.IsSuccess = false;
        result.Code = CommonErrorCode.Unauthorized;
        result.Message = message;
        return result;
    }

    // Forbidden method
    public static Result Forbidden(this Result result, string message)
    {
        result.IsSuccess = false;
        result.Code = CommonErrorCode.Forbidden;
        result.Message = message;
        return result;
    }
    public static Result<T> Forbidden<T>(this Result<T> result, string message)
    {
        result.IsSuccess = false;
        result.Code = CommonErrorCode.Forbidden;
        result.Message = message;
        return result;
    }

    // NotFound method
    public static Result NotFound(this Result result, string message)
    {
        result.IsSuccess = false;
        result.Code = CommonErrorCode.NotFound;
        result.Message = message;
        return result;
    }
    public static Result<T> NotFound<T>(this Result<T> result, string message)
    {
        result.IsSuccess = false;
        result.Code = CommonErrorCode.NotFound;
        result.Message = message;
        return result;
    }

    // InternalServerError method
    public static Result ServerError(this Result result, string message)
    {
        result.IsSuccess = false;
        result.Code = CommonErrorCode.ServerError;
        result.Message = message;
        return result;
    }
    public static Result<T> ServerError<T>(this Result<T> result, string message)
    {
        result.IsSuccess = false;
        result.Code = CommonErrorCode.ServerError;
        result.Message = message;
        return result;
    }
}

public static class CustomResultExtension
{
    // BadRequest method,
    // Need to define the custom error code in ErrorCode.cs
    public static Result CustomError(this Result result, int code, string message)
    {
        result.IsSuccess = false;
        result.Code = code;
        result.Message = message;
        return result;
    }
    public static Result<T> CustomError<T>(this Result<T> result, int code, string message)
    {
        result.IsSuccess = false;
        result.Code = code;
        result.Message = message;
        return result;
    }
}
