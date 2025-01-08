﻿// <auto-generated />
using System;
using GetMyTicket.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GetMyTicket.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250108091301_AddCountyAndCityEntity")]
    partial class AddCountyAndCityEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GetMyTicket.Common.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.BaggageItem", b =>
                {
                    b.Property<Guid>("BaggageItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PassengerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BaggageItemId");

                    b.HasIndex("BookingId");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TripId");

                    b.ToTable("BaggageItem");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Booking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BookingStatus")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("TripId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingId");

                    b.HasIndex("TripId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.City", b =>
                {
                    b.Property<Guid>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IATA_Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Contracts.Passenger", b =>
                {
                    b.Property<Guid>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.HasKey("PassengerId");

                    b.ToTable("Passenger");

                    b.HasDiscriminator().HasValue("Passenger");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Contracts.Vehicle", b =>
                {
                    b.Property<Guid>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<Guid>("TransportationProvideriD")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VehicleId");

                    b.HasIndex("TransportationProvideriD");

                    b.ToTable("Vehicle");

                    b.HasDiscriminator().HasValue("Vehicle");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Country", b =>
                {
                    b.Property<Guid>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.TransportationProvider", b =>
                {
                    b.Property<Guid>("TransportationProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("TransportationProviderId");

                    b.ToTable("TransportationProviders");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Trip", b =>
                {
                    b.Property<Guid>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Currency")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("EndCityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("StartCityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TransportationProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TypeOfTransportation")
                        .HasColumnType("int");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TripId");

                    b.HasIndex("EndCityId");

                    b.HasIndex("StartCityId");

                    b.HasIndex("TransportationProviderId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Tips");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsSubscribedForNewsletter")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("RegistrationDate")
                        .HasColumnType("date");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("GetMyTicket.Common.Mapping_Tables.PassengerBookingMap", b =>
                {
                    b.Property<Guid>("PassengerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PassengerId", "BookingId");

                    b.HasIndex("BookingId");

                    b.ToTable("PassengerBookingMap");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Passengers.Adult", b =>
                {
                    b.HasBaseType("GetMyTicket.Common.Entities.Contracts.Passenger");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("Adult");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Passengers.Child", b =>
                {
                    b.HasBaseType("GetMyTicket.Common.Entities.Contracts.Passenger");

                    b.HasDiscriminator().HasValue("Child");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Passengers.Infant", b =>
                {
                    b.HasBaseType("GetMyTicket.Common.Entities.Contracts.Passenger");

                    b.HasDiscriminator().HasValue("Infant");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Vehicles.Airplane", b =>
                {
                    b.HasBaseType("GetMyTicket.Common.Entities.Contracts.Vehicle");

                    b.Property<int>("AirplaneManufacturer")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ManufacturingDate")
                        .HasColumnType("date");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Airplane");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Vehicles.Bus", b =>
                {
                    b.HasBaseType("GetMyTicket.Common.Entities.Contracts.Vehicle");

                    b.Property<bool>("HasToiletOnBoard")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Bus");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Vehicles.Train", b =>
                {
                    b.HasBaseType("GetMyTicket.Common.Entities.Contracts.Vehicle");

                    b.Property<bool>("HasBistroOnBoard")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAHighspeedTrain")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Train");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.BaggageItem", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.Booking", null)
                        .WithMany("BaggageItems")
                        .HasForeignKey("BookingId");

                    b.HasOne("GetMyTicket.Common.Entities.Contracts.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetMyTicket.Common.Entities.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Booking", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.Trip", "Trip")
                        .WithMany("Bookings")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.City", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.Country", null)
                        .WithMany("Destinations")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Contracts.Vehicle", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.TransportationProvider", "TransportationProvider")
                        .WithMany("Vehicles")
                        .HasForeignKey("TransportationProvideriD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransportationProvider");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Trip", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.City", "EndCity")
                        .WithMany()
                        .HasForeignKey("EndCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetMyTicket.Common.Entities.City", "StartCity")
                        .WithMany()
                        .HasForeignKey("StartCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetMyTicket.Common.Entities.TransportationProvider", "TransportationProvider")
                        .WithMany("Trips")
                        .HasForeignKey("TransportationProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetMyTicket.Common.Entities.Contracts.Vehicle", "Vehicle")
                        .WithMany("Trips")
                        .HasForeignKey("VehicleId")
                        .IsRequired();

                    b.Navigation("EndCity");

                    b.Navigation("StartCity");

                    b.Navigation("TransportationProvider");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("GetMyTicket.Common.Mapping_Tables.PassengerBookingMap", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.Booking", "Booking")
                        .WithMany("PassengerBookingMap")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetMyTicket.Common.Entities.Contracts.Passenger", "Passenger")
                        .WithMany("PassengerBookingMap")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GetMyTicket.Common.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Passengers.Adult", b =>
                {
                    b.HasOne("GetMyTicket.Common.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Booking", b =>
                {
                    b.Navigation("BaggageItems");

                    b.Navigation("PassengerBookingMap");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Contracts.Passenger", b =>
                {
                    b.Navigation("PassengerBookingMap");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Contracts.Vehicle", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Country", b =>
                {
                    b.Navigation("Destinations");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.TransportationProvider", b =>
                {
                    b.Navigation("Trips");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("GetMyTicket.Common.Entities.Trip", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
