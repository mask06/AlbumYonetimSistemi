﻿// <auto-generated />
using System;
using AYS_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AYS_DAL.Migrations
{
    [DbContext(typeof(AYS_DBContext))]
    partial class AYS_DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AYS_DAL.Entities.Concrete.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                            IsActive = true,
                            Name = "mustafa",
                            Password = "DE659F7F95F5C6B909D823DC130BFE95E85B3E4E1F1019299E1D6DEBA318D113"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                            IsActive = true,
                            Name = "yonca",
                            Password = "DE659F7F95F5C6B909D823DC130BFE95E85B3E4E1F1019299E1D6DEBA318D113"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                            IsActive = true,
                            Name = "göksel",
                            Password = "DE659F7F95F5C6B909D823DC130BFE95E85B3E4E1F1019299E1D6DEBA318D113"
                        });
                });

            modelBuilder.Entity("AYS_DAL.Entities.Concrete.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Artist = "Serdar Ortaç",
                            Created = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                            Discount = 0m,
                            IsActive = false,
                            Name = "Mesafe",
                            Price = 55m,
                            ReleaseDate = new DateOnly(2006, 1, 5),
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Artist = "Teoman",
                            Created = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                            Discount = 0m,
                            IsActive = false,
                            Name = "Onyedi",
                            Price = 955m,
                            ReleaseDate = new DateOnly(2000, 4, 28),
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            Artist = "Eurythmics",
                            Created = new DateTime(2024, 10, 10, 11, 43, 33, 234, DateTimeKind.Local).AddTicks(5286),
                            Discount = 0m,
                            IsActive = false,
                            Name = "Touch",
                            Price = 455m,
                            ReleaseDate = new DateOnly(1983, 1, 1),
                            Status = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}