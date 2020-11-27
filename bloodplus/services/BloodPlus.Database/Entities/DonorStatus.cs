using System.ComponentModel.DataAnnotations;

namespace BloodPlus.Database.Entities
{
    public class DonorStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public int UnavailableForDays { get; set; }
    }
}
