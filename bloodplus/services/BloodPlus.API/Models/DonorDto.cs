namespace BloodPlus.API.Models
{
    public class DonorDto
    {
        public class Request
        {
            public int CityId { get; set; }
            public string BloodGroup { get; set; }
            public int Limit { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Contact { get; set; }
        }
    }
}
