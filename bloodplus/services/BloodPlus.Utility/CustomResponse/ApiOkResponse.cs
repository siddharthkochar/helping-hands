namespace BloodPlus.Utility.CustomResponse
{
    public class ApiOkResponse : ApiResponse
    {
        public ApiOkResponse(object result) : base(result, true)
        {
        }
    }
}
