using System;

namespace BloodPlus.API.Models
{
    public class DonorDto
    {
        public class Request
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Contact { get; set; }
            public DateTime BirthDate { get; set; }
            public int CityId { get; set; }
            public int StatusId { get; set; }
            public int GenderId { get; set; }
            public int BloodGroupId { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Contact { get; set; }
        }
    }
}
