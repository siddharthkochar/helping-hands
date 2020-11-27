﻿// <auto-generated />
using System;
using BloodPlus.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloodPlus.Database.Migrations
{
    [DbContext(typeof(BloodPlusDatabaseContext))]
    [Migration("20201127085003_AddDonorStatusTable")]
    partial class AddDonorStatusTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BloodPlus.Database.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId", "Name")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "India"
                        });
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.Donor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BloodGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DonorStatusId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UnavailableTill")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Contact")
                        .IsUnique();

                    b.HasIndex("DonorStatusId");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.DonorStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UnavailableForDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Status")
                        .IsUnique()
                        .HasFilter("[Status] IS NOT NULL");

                    b.ToTable("DonorStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Available",
                            UnavailableForDays = 0
                        },
                        new
                        {
                            Id = 2,
                            Status = "Verification needed",
                            UnavailableForDays = 36500
                        },
                        new
                        {
                            Id = 3,
                            Status = "Unreachable",
                            UnavailableForDays = 1
                        },
                        new
                        {
                            Id = 4,
                            Status = "Unwell",
                            UnavailableForDays = 7
                        },
                        new
                        {
                            Id = 5,
                            Status = "Donated",
                            UnavailableForDays = 120
                        },
                        new
                        {
                            Id = 6,
                            Status = "Out of station",
                            UnavailableForDays = 7
                        });
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.LookupType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("LookupTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gender"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BloodGroup"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Status"
                        },
                        new
                        {
                            Id = 4,
                            Name = "UserActivity"
                        });
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.LookupValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("LookupTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LookupTypeId", "Value")
                        .IsUnique();

                    b.ToTable("LookupValues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LookupTypeId = 1,
                            Value = "M"
                        },
                        new
                        {
                            Id = 2,
                            LookupTypeId = 1,
                            Value = "F"
                        },
                        new
                        {
                            Id = 3,
                            LookupTypeId = 2,
                            Value = "AB+"
                        },
                        new
                        {
                            Id = 4,
                            LookupTypeId = 2,
                            Value = "AB-"
                        },
                        new
                        {
                            Id = 5,
                            LookupTypeId = 2,
                            Value = "A+"
                        },
                        new
                        {
                            Id = 6,
                            LookupTypeId = 2,
                            Value = "A-"
                        },
                        new
                        {
                            Id = 7,
                            LookupTypeId = 2,
                            Value = "B+"
                        },
                        new
                        {
                            Id = 8,
                            LookupTypeId = 2,
                            Value = "B-"
                        },
                        new
                        {
                            Id = 9,
                            LookupTypeId = 2,
                            Value = "O+"
                        },
                        new
                        {
                            Id = 10,
                            LookupTypeId = 2,
                            Value = "O-"
                        });
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId", "Name")
                        .IsUnique();

                    b.ToTable("States");
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.UserActivityLog", b =>
                {
                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("UserActivityLogs");
                });

            modelBuilder.Entity("CityDonor", b =>
                {
                    b.Property<int>("CitiesId")
                        .HasColumnType("int");

                    b.Property<int>("DonorsId")
                        .HasColumnType("int");

                    b.HasKey("CitiesId", "DonorsId");

                    b.HasIndex("DonorsId");

                    b.ToTable("CityDonor");
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.City", b =>
                {
                    b.HasOne("BloodPlus.Database.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.Donor", b =>
                {
                    b.HasOne("BloodPlus.Database.Entities.DonorStatus", "DonorStatus")
                        .WithMany()
                        .HasForeignKey("DonorStatusId");

                    b.Navigation("DonorStatus");
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.LookupValue", b =>
                {
                    b.HasOne("BloodPlus.Database.Entities.LookupType", "LookupType")
                        .WithMany()
                        .HasForeignKey("LookupTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LookupType");
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.State", b =>
                {
                    b.HasOne("BloodPlus.Database.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CityDonor", b =>
                {
                    b.HasOne("BloodPlus.Database.Entities.City", null)
                        .WithMany()
                        .HasForeignKey("CitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodPlus.Database.Entities.Donor", null)
                        .WithMany()
                        .HasForeignKey("DonorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}