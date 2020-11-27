namespace BloodPlus.API.CustomResponse
{
    public class ApiOkResponse : ApiResponse
    {
        public ApiOkResponse(object result) : base(result, true)
        {
        }
    }
}
