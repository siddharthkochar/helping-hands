namespace BloodPlus.API.CustomResponse
{
    public class ApiBadResponse : ApiResponse
    {
        public ApiBadResponse(string error) : base(error, false)
        {
        }
    }
}
