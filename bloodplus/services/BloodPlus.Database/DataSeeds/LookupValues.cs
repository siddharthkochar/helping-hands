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
                new LookupValue {Id = 10, LookupTypeId = 2, Value = "O-"}
            );
        }
    }
}
