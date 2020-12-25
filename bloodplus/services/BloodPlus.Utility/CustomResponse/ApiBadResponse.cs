namespace BloodPlus.Utility.CustomResponse
{
    public class ApiBadResponse : ApiResponse
    {
        public ApiBadResponse(string error) : base(error, false)
        {
        }
    }
}
