using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodPlus.API.Constants
{ 
    public class CityRepresentative
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Contact { get; set; }

        const string DefaultRepresentative = "1234567890";

        private static readonly IEnumerable<CityRepresentative> _representatives 
            = new CityRepresentative[]
            {
                new CityRepresentative { City = "Raipur", State = "Chhattisgarh", Contact = "9876543210" }
            };

        public static string Get(string city, string state)
        {
            var representative = _representatives.FirstOrDefault(x =>
                x.City.Equals(city, StringComparison.OrdinalIgnoreCase) &&
                x.State.Equals(state, StringComparison.OrdinalIgnoreCase));

            return representative == null ? DefaultRepresentative : representative.Contact;
        }
    }
}
