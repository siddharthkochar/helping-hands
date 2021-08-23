using System;
using System.Collections.Generic;

namespace BloodPlus.Database
{
    public partial class OldDonor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
        public string Bloodgroup { get; set; }
        public string Contact { get; set; }
        public byte State { get; set; }
        public short City { get; set; }
        public string Availability { get; set; }
        public DateTime? Date { get; set; }
    }
}
