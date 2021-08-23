using System.Collections.Generic;

namespace BloodPlus.Services.Model
{
    public class Region
    {
        public IEnumerable<Data> Data { get; set; }
        public IEnumerable<Links> Links { get; set; }
    }

    public class Data
    {
        public string Name { get; set; }
        public string Region { get; set; }
    }

    public class Links
    {
        public string Rel { get; set; }
        public string Href { get; set; }
    }
}
