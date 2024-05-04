﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using partycli.Database;

#nullable disable

namespace partycli.Migrations
{
    [DbContext(typeof(PartyCliDbContext))]
    [Migration("20240504043102_LocationsAndCountry")]
    partial class LocationsAndCountry
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("partycli.Models.Entities.ConfigModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("partycli.Models.Entities.CountryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("Id");

                    b.ToTable("CountryModel");

                    b.HasAnnotation("Relational:JsonPropertyName", "country");
                });

            modelBuilder.Entity("partycli.Models.Entities.LocationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CountryId")
                        .IsUnique();

                    b.HasIndex("ServerId");

                    b.ToTable("LocationModel");

                    b.HasAnnotation("Relational:JsonPropertyName", "locations");
                });

            modelBuilder.Entity("partycli.Models.Entities.LogModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Action")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("partycli.Models.Entities.ServerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<int>("Load")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "load");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "status");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("partycli.Models.Entities.ConfigModel", b =>
                {
                    b.HasOne("partycli.Models.Entities.ServerModel", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("partycli.Models.Entities.LocationModel", b =>
                {
                    b.HasOne("partycli.Models.Entities.CountryModel", "Country")
                        .WithOne("Location")
                        .HasForeignKey("partycli.Models.Entities.LocationModel", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("partycli.Models.Entities.ServerModel", "Server")
                        .WithMany("Locations")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("partycli.Models.Entities.CountryModel", b =>
                {
                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("partycli.Models.Entities.ServerModel", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
