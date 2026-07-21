namespace UserManagementWebAPI.Response
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }

        public static ApiResponse<T> Success(T? data)
        {
            return new ApiResponse<T>
            {
                Data = data,
                IsSuccess = true
            };
        }

        public static ApiResponse<T> Failure(string? errorMessage)
        {
            return new ApiResponse<T>
            {
                ErrorMessage = errorMessage,
                IsSuccess = false
            };
        }
    }
}
