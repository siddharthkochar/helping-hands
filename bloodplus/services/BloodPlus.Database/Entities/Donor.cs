using System;
using System.ComponentModel.DataAnnotations;

namespace BloodPlus.Database.Entities
{
    public class Donor : BaseLookupEntity
    {
        [Required]
        public int GenderId { get; set; }
        [Required]
        public int BloodGroupId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Contact { get; set; }
    }
}
