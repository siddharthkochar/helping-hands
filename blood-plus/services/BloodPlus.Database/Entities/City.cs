namespace BloodPlus.Database.Entities
{
    public class City : BaseLookupEntity
    {
        public int StateId { get; set; }
        public State State { get; set; }
    }
}