﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Staycation.Api.Data.Access;

#nullable disable

namespace Staycation.Api.Migrations
{
    [DbContext(typeof(AccommodationContext))]
    partial class AccommodationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Staycation.Api.Data.Models.Accommodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Categorization")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool?>("FreeCancelation")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("PersonCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Subtitle")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("Staycation.Api.Data.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Staycation.Api.Data.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PersonCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Staycation.Api.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Staycation.Api.Data.Models.Accommodation", b =>
                {
                    b.HasOne("Staycation.Api.Data.Models.Location", "Location")
                        .WithMany("Accommodations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Staycation.Api.Data.Models.Reservation", b =>
                {
                    b.HasOne("Staycation.Api.Data.Models.Accommodation", "Accommodation")
                        .WithMany("Reservations")
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");
                });

            modelBuilder.Entity("Staycation.Api.Data.Models.Accommodation", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Staycation.Api.Data.Models.Location", b =>
                {
                    b.Navigation("Accommodations");
                });
#pragma warning restore 612, 618
        }
    }
}
