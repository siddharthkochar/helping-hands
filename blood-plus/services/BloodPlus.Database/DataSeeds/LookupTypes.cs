using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodPlus.Database.DataSeeds
{
    public class LookupTypes : IEntityTypeConfiguration<LookupType>
    {
        public void Configure(EntityTypeBuilder<LookupType> builder)
        {
            builder.HasData(
                new LookupType {Id = 1, Name = "Gender"},
                new LookupType {Id = 2, Name = "BloodGroup"},
                new LookupType {Id = 3, Name = "Status"},
                new LookupType {Id = 4, Name = "UserActivity"});
        }
    }
}
