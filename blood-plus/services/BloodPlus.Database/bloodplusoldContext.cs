using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BloodPlus.Database
{
    public partial class bloodplusoldContext : DbContext
    {
        public bloodplusoldContext()
        {
        }

        public bloodplusoldContext(DbContextOptions<bloodplusoldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<OldDonor> OldDonors { get; set; }
        public virtual DbSet<States> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=bloodplus-old;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.StateId).HasColumnName("state_id");
            });

            modelBuilder.Entity<OldDonor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("donor");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Availability)
                    .IsRequired()
                    .HasColumnName("availability")
                    .HasMaxLength(50);

                entity.Property(e => e.Bloodgroup)
                    .IsRequired()
                    .HasColumnName("bloodgroup")
                    .HasMaxLength(50);

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasMaxLength(200);

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("states");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
