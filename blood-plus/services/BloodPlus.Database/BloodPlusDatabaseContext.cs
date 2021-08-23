using BloodPlus.Database.DataSeeds;
using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BloodPlus.Database
{
    public class BloodPlusDatabaseContext : DbContext
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
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=bloodplus-v1;Integrated Security=True");
        }

        private void RemoveAllCascade(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RemoveAllCascade(modelBuilder);
            base.OnModelCreating(modelBuilder);

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
        }
    }
}
