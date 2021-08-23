using System;
using System.Collections.Generic;

namespace BloodPlus.Database
{
    public partial class States
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte CountryId { get; set; }
    }
}
