using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodPlus.Database.DataSeeds
{
    public class LookupValues : IEntityTypeConfiguration<LookupValue>
    {
        public void Configure(EntityTypeBuilder<LookupValue> builder)
        {
            builder.HasData(
                new LookupValue {Id = 1, LookupTypeId = 1, Value = "M"},
                new LookupValue {Id = 2, LookupTypeId = 1, Value = "F"},
                new LookupValue {Id = 3, LookupTypeId = 2, Value = "AB+"},
                new LookupValue {Id = 4, LookupTypeId = 2, Value = "AB-"},
                new LookupValue {Id = 5, LookupTypeId = 2, Value = "A+"},
                new LookupValue {Id = 6, LookupTypeId = 2, Value = "A-"},
                new LookupValue {Id = 7, LookupTypeId = 2, Value = "B+"},
                new LookupValue {Id = 8, LookupTypeId = 2, Value = "B-"},
                new LookupValue {Id = 9, LookupTypeId = 2, Value = "O+"},
                new LookupValue {Id = 10, LookupTypeId = 2, Value = "O-"},
                new LookupValue {Id = 11, LookupTypeId = 3, Value = "Available"},
                new LookupValue {Id = 12, LookupTypeId = 3, Value = "Fake"},
                new LookupValue {Id = 13, LookupTypeId = 3, Value = "Inappropriate"},
                new LookupValue {Id = 14, LookupTypeId = 3, Value = "More"},
                new LookupValue {Id = 15, LookupTypeId = 3, Value = "Unreachable"},
                new LookupValue {Id = 16, LookupTypeId = 3, Value = "Other"},
                new LookupValue {Id = 17, LookupTypeId = 3, Value = "Not Well"},
                new LookupValue {Id = 18, LookupTypeId = 3, Value = "Nine"},
                new LookupValue {Id = 19, LookupTypeId = 3, Value = "false"},
                new LookupValue {Id = 20, LookupTypeId = 4, Value = "Search"},
                new LookupValue {Id = 21, LookupTypeId = 4, Value = "Feedback"},
                new LookupValue {Id = 22, LookupTypeId = 4, Value = "Register"}
            );
        }
    }
}
