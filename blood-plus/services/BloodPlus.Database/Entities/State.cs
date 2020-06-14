namespace BloodPlus.Database.Entities
{
    public class State : BaseLookupEntity
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}