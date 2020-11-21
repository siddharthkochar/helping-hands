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
    [Migration("20201121072737_MakeBirthDateRequired")]
    partial class MakeBirthDateRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BloodPlus.Database.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BloodGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Contact")
                        .IsUnique();

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.DonorCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("DonorId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("StateId");

                    b.HasIndex("DonorId", "CityId")
                        .IsUnique();

                    b.ToTable("DonorCities");
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.LookupType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        },
                        new
                        {
                            Id = 11,
                            LookupTypeId = 3,
                            Value = "Available"
                        },
                        new
                        {
                            Id = 12,
                            LookupTypeId = 3,
                            Value = "Fake"
                        },
                        new
                        {
                            Id = 13,
                            LookupTypeId = 3,
                            Value = "Inappropriate"
                        },
                        new
                        {
                            Id = 14,
                            LookupTypeId = 3,
                            Value = "More"
                        },
                        new
                        {
                            Id = 15,
                            LookupTypeId = 3,
                            Value = "Unreachable"
                        },
                        new
                        {
                            Id = 16,
                            LookupTypeId = 3,
                            Value = "Other"
                        },
                        new
                        {
                            Id = 17,
                            LookupTypeId = 3,
                            Value = "Not Well"
                        },
                        new
                        {
                            Id = 18,
                            LookupTypeId = 3,
                            Value = "Nine"
                        },
                        new
                        {
                            Id = 19,
                            LookupTypeId = 3,
                            Value = "false"
                        },
                        new
                        {
                            Id = 20,
                            LookupTypeId = 4,
                            Value = "Search"
                        },
                        new
                        {
                            Id = 21,
                            LookupTypeId = 4,
                            Value = "Feedback"
                        },
                        new
                        {
                            Id = 22,
                            LookupTypeId = 4,
                            Value = "Register"
                        });
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("BloodPlus.Database.Entities.City", b =>
                {
                    b.HasOne("BloodPlus.Database.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.DonorCity", b =>
                {
                    b.HasOne("BloodPlus.Database.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodPlus.Database.Entities.Donor", "Donor")
                        .WithMany()
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodPlus.Database.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.LookupValue", b =>
                {
                    b.HasOne("BloodPlus.Database.Entities.LookupType", "LookupType")
                        .WithMany()
                        .HasForeignKey("LookupTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BloodPlus.Database.Entities.State", b =>
                {
                    b.HasOne("BloodPlus.Database.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}