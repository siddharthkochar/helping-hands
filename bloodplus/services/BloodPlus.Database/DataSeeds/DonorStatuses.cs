using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodPlus.Database.DataSeeds
{
    public class DonorStatuses : IEntityTypeConfiguration<DonorStatus>
    {
        public void Configure(EntityTypeBuilder<DonorStatus> builder)
        {
            builder.HasData(
                new DonorStatus { Id = 1, Status = "Available", UnavailableForDays = 0 },
                new DonorStatus { Id = 2, Status = "Verification needed", UnavailableForDays = 36500 },
                new DonorStatus { Id = 3, Status = "Unreachable", UnavailableForDays = 1 },
                new DonorStatus { Id = 4, Status = "Unwell", UnavailableForDays = 7 },
                new DonorStatus { Id = 5, Status = "Donated", UnavailableForDays = 120 },
                new DonorStatus { Id = 6, Status = "Out of station", UnavailableForDays = 7 });
        }
    }
}
