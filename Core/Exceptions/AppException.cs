namespace Core.Exceptions;

public class AppException : Exception
{
    // Code
    public int Code { get; set; }

    public AppException(int code, string message) : base(message)
    {
        Code = code;
    }
}
