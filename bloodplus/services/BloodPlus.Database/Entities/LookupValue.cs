using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodPlus.Database.Entities
{
    public class LookupValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        public int LookupTypeId { get; set; }
        public LookupType LookupType { get; set; }
    }
}