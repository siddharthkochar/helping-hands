using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodPlus.Database
{
    public interface IBloodPlusDatabaseContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Donor> Donors { get; set; }
        DbSet<DonorCity> DonorCities { get; set; }
        DbSet<LookupType> LookupTypes { get; set; }
        DbSet<LookupValue> LookupValues { get; set; }
        DbSet<State> States { get; set; }
        DbSet<UserActivityLog> UserActivityLogs { get; set; }
    }

    public class BloodPlusDatabaseContext : DbContext, IBloodPlusDatabaseContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<DonorCity> DonorCities { get; set; }
        public DbSet<LookupType> LookupTypes { get; set; }
        public DbSet<LookupValue> LookupValues { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<UserActivityLog> UserActivityLogs { get; set; }
        public DbSet<City> Cities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=bloodplus;Integrated Security=True");
        }

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
        }
    }
}
