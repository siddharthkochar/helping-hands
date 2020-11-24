using System.Collections.Generic;

namespace BloodPlus.Database.Entities
{
    public class City : BaseLookupEntity
    {
        public int StateId { get; set; }
        public State State { get; set; }

        public ICollection<Donor> Donors { get; set; }
    }
}