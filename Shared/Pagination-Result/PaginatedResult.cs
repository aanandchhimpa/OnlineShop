namespace Shared.Pagination_Result
{
    public class PaginatedResult<T> : Result<List<T>>
    {
        public PaginatedResult(List<T> data, int count, int pageNumber, int pageSize, bool succeeded = true, List<string> messages = null)
        {
            Data = data; // Ensure Data is never null
            TotalCount = count;
            PageSize = pageSize > 0 ? pageSize : 10;
            CurrentPage = pageNumber > 0 ? pageNumber : 1;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            Succeeded = succeeded;
            Messages = messages ?? new List<string>();
        }

        public int CurrentPage { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public int PageSize { get; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        // ✅ Create a Success Paginated Result
        public static PaginatedResult<T> Create(List<T> data, int count, int pageNumber, int pageSize)
        {
            return new PaginatedResult<T>(data, count, pageNumber, pageSize, true);
        }

        // ✅ Not Found (Empty List)
        public static PaginatedResult<T> NotFound(string message = "No records found.")
        {
            return new PaginatedResult<T>(new List<T>(), 0, 1, 10, false, new List<string> { message });
        }

        // ✅ Failure (Error Messages)
        public static PaginatedResult<T> Failure(List<string> messages)
        {
            return new PaginatedResult<T>(new List<T>(), 0, 1, 10, false, messages);
        }

        // ✅ Failure (Single Error Message)
        public static PaginatedResult<T> Failure(string message)
        {
            return new PaginatedResult<T>(new List<T>(), 0, 1, 10, false, new List<string> { message });
        }

        // ✅ No Content (Like HTTP 204)
        public static PaginatedResult<T> NoContent()
        {
            return new PaginatedResult<T>(new List<T>(), 0, 1, 10, true, new List<string> { "No content available." });
        }

        // ✅ Unauthorized Access (Like HTTP 401)
        public static PaginatedResult<T> Unauthorized(string message = "Unauthorized access.")
        {
            return new PaginatedResult<T>(new List<T>(), 0, 1, 10, false, new List<string> { message });
        }

        // ✅ Forbidden (Like HTTP 403)
        public static PaginatedResult<T> Forbidden(string message = "Access is forbidden.")
        {
            return new PaginatedResult<T>(new List<T>(), 0, 1, 10, false, new List<string> { message });
        }

        // ✅ Bad Request (Like HTTP 400)
        public static PaginatedResult<T> BadRequest(string message)
        {
            return new PaginatedResult<T>(new List<T>(), 0, 1, 10, false, new List<string> { message });
        }

        // ✅ Internal Server Error (Like HTTP 500)
        public static PaginatedResult<T> InternalServerError(string message = "An unexpected error occurred.")
        {
            return new PaginatedResult<T>(new List<T>(), 0, 1, 10, false, new List<string> { message });
        }
    }


}
