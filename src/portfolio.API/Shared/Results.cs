namespace portfolio.API.Shared;

public class Results<T>
{
    public T Success { get; private set; } = default!;
    public string? Error { get; private set; }
    private Results() { }
    public static Results<T> SuccessResult(T data)
    {
        return new Results<T> { Success = data };
    }

    public static Results<T> ErrorResult(string errorMessage)
    {
        return new Results<T> { Error = errorMessage };
    }

    public bool IsSuccess => Success != null;
    public bool IsError => Error != null;

    public override string ToString()
    {
        if (IsSuccess)
            return $"Success: {Success}";
        else if (IsError)
            return $"Error: {Error}";
        else
            return "No result";
    }

}