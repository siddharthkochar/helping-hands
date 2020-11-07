using System.ComponentModel.DataAnnotations;

namespace BloodPlus.Database.Entities
{
    public class DonorCity
    {
        [Key]
        public int Id { get; set; }

        public Donor Donor { get; set; }
        public int DonorId { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }

        public State State { get; set; }
        public int StateId { get; set; }
    }
}
