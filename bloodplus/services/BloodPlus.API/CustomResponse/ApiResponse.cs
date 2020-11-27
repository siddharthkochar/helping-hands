namespace BloodPlus.API.CustomResponse
{
    public class ApiResponse
    {
        public ApiResponse(object value, bool isSuccess)
        {
            Value = value;
            IsSuccess = isSuccess;
        }

        public object Value { get; }

        public bool IsSuccess { get; }
    }
}
