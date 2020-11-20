using BloodPlus.Database.DataSeeds;
using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BloodPlus.Database
{
    public class BloodPlusDatabaseContext : DbContext
    {
        public BloodPlusDatabaseContext(DbContextOptions<BloodPlusDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<DonorCity> DonorCities { get; set; }
        public DbSet<LookupType> LookupTypes { get; set; }
        public DbSet<LookupValue> LookupValues { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<UserActivityLog> UserActivityLogs { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<State>()
                .HasIndex(x => new {x.CountryId, x.Name})
                .IsUnique();

            modelBuilder.Entity<City>()
                .HasIndex(x => new {x.StateId, x.Name})
                .IsUnique();

            modelBuilder.Entity<LookupValue>()
                .HasIndex(x => new {x.LookupTypeId, x.Value})
                .IsUnique();

            modelBuilder.Entity<Donor>()
                .HasIndex(x => x.Contact)
                .IsUnique();

            modelBuilder.Entity<DonorCity>()
                .HasIndex(x => new {x.DonorId, x.CityId})
                .IsUnique();

            modelBuilder.Entity<UserActivityLog>()
                .HasNoKey();

            modelBuilder.ApplyConfiguration(new LookupTypes());
            modelBuilder.ApplyConfiguration(new LookupValues());
            modelBuilder.ApplyConfiguration(new Countries());
            modelBuilder.ApplyConfiguration(new DataSeeds.States());
        }
    }
}
