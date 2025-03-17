namespace Shared.Pagination_Result
{
    public class Result<T>
    {
        public List<string> Messages { get; set; } = new List<string>();
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public string Token { get; set; }
        public Exception Exception { get; set; }
        public int Code { get; set; }

        #region Non-Async Methods

        #region Success Methods

        public static Result<T> Success() => new() { Succeeded = true };

        public static Result<T> Success(string message) => new()
        {
            Succeeded = true,
            Messages = new List<string> { message }
        };

        public static Result<string> SuccessToken(string token) => new()
        {
            Succeeded = true,
            Token = token
        };

        public static Result<T> Success(T data) => new()
        {
            Succeeded = true,
            Data = data
        };

        public static Result<T> Success(T data, string message) => new()
        {
            Succeeded = true,
            Messages = new List<string> { message },
            Data = data
        };

        #endregion

        #region Failure Methods

        public static Result<T> Failure() => new() { Succeeded = false };

        public static Result<T> Failure(string message) => new()
        {
            Succeeded = false,
            Messages = new List<string> { message }
        };

        public static Result<T> Failure(List<string> messages) => new()
        {
            Succeeded = false,
            Messages = messages
        };

        public static Result<T> Failure(T data) => new()
        {
            Succeeded = false,
            Data = data
        };

        public static Result<T> Failure(T data, string message) => new()
        {
            Succeeded = false,
            Messages = new List<string> { message },
            Data = data
        };

        public static Result<T> Failure(T data, List<string> messages) => new()
        {
            Succeeded = false,
            Messages = messages,
            Data = data
        };

        public static Result<T> Failure(Exception exception) => new()
        {
            Succeeded = false,
            Exception = exception
        };

        #endregion

        #endregion

        #region Async Methods

        #region Success Methods

        public static Task<Result<T>> SuccessAsync() => Task.FromResult(Success());

        public static Task<Result<T>> SuccessAsync(string message) => Task.FromResult(Success(message));

        public static Task<Result<string>> SuccessTokenAsync(string token) => Task.FromResult(SuccessToken(token));

        public static Task<Result<T>> SuccessAsync(T data) => Task.FromResult(Success(data));

        public static Task<Result<T>> SuccessAsync(T data, string message) => Task.FromResult(Success(data, message));

        #endregion

        #region Failure Methods

        public static Task<Result<T>> FailureAsync() => Task.FromResult(Failure());

        public static Task<Result<T>> FailureAsync(string message) => Task.FromResult(Failure(message));

        public static Task<Result<T>> FailureAsync(List<string> messages) => Task.FromResult(Failure(messages));

        public static Task<Result<T>> FailureAsync(T data) => Task.FromResult(Failure(data));

        public static Task<Result<T>> FailureAsync(T data, string message) => Task.FromResult(Failure(data, message));

        public static Task<Result<T>> FailureAsync(T data, List<string> messages) => Task.FromResult(Failure(data, messages));

        public static Task<Result<T>> FailureAsync(Exception exception) => Task.FromResult(Failure(exception));

        #endregion

        #endregion
    }

}
