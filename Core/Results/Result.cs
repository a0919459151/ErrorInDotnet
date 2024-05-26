namespace Core.Results;

public class Result
{
    public bool IsSuccess { get; set; }

    public bool IsFailure => !IsSuccess;

    public string Code { get; set; }

    public string Message { get; set; } = null!;

    public dynamic? Value { get; set; }

    protected Result(bool isSuccess, string code, string message)
    {
        IsSuccess = isSuccess;
        Code = code;
        Message = message;
    }

    protected Result(bool isSuccess, string code, string message, dynamic value)
        : this(isSuccess, code, message)
    {
        Value = value;
    }

    // Success
    public static Result Success()
        => new Result(true, CommonErrorCode.Success, "Success");

    // Success with message
    public static Result Success(string message)
        => new Result(true, CommonErrorCode.Success, message);

    // Success with value
    public static Result Success(dynamic value)
        => new Result(true, CommonErrorCode.Success, "Success", value);

    // 400 BadRequest
    public static Result BadRequest(string message)
        => new Result(false, CommonErrorCode.BadRequest, message);

    // 401 Unauthorized
    public static Result Unauthorized(string message)
        => new Result(false, CommonErrorCode.Unauthorized, message);

    // 403 Forbidden
    public static Result Forbidden(string message)
        => new Result(false, CommonErrorCode.Forbidden, message);

    // 404 NotFound
    public static Result NotFound(string message)
        => new Result(false, CommonErrorCode.NotFound, message);

    // 500 InternalServerError
    public static Result InternalServerError(string message)
        => new Result(false, CommonErrorCode.ServerError, message);

    // CustomError
    public static Result CustomError(string code, string message)
        => new Result(false, code, message);
}
