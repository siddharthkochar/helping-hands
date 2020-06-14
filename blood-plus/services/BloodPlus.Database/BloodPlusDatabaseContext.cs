using System;
using BloodPlus.Database.DataSeeds;
using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodPlus.Database
{
    public class BloodPlusDatabaseContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=bloodplus-test;Integrated Security=True");
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
        }
    }
}
