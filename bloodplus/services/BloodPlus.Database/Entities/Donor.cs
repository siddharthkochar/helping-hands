using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodPlus.Database.Entities
{
    public class Donor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
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

        public ICollection<City> Cities { get; set; }
    }
}
