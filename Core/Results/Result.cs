using System.Net;

namespace Core.Results;

public class Result
{
    public bool IsSuccess { get; set; }

    public int Code { get; set; }

    public string Message { get; set; }
}

public class Result<T> : Result
{
    public T? Data { get; set; }
}