﻿// <auto-generated />
using System;
using BackendApartmentReservation.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackendApartmentReservation.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190525170942_AddFileToFlightInfo")]
    partial class AddFileToFlightInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.Amenities.DbCarRentAmenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("BookedAt");

                    b.Property<int?>("CarReservationId");

                    b.HasKey("Id");

                    b.HasIndex("CarReservationId");

                    b.ToTable("CarRentAmenities");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.Amenities.DbFlightAmenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("BookedAt");

                    b.Property<int?>("FlightReservationId");

                    b.Property<int?>("TicketId");

                    b.HasKey("Id");

                    b.HasIndex("FlightReservationId");

                    b.HasIndex("TicketId");

                    b.ToTable("FlightAmenities");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.Amenities.DbLivingPlaceAmenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApartmentRoomReservationId");

                    b.Property<DateTimeOffset?>("BookedAt");

                    b.Property<int?>("HotelReservationId");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentRoomReservationId");

                    b.HasIndex("HotelReservationId");

                    b.ToTable("LivingPlaceAmenities");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbApartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.HasKey("Id");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbApartmentRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DbApartmentId");

                    b.Property<int>("RoomNumber");

                    b.HasKey("Id");

                    b.HasIndex("DbApartmentId");

                    b.ToTable("ApartmentRooms");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbAuthorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Authorizations");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbConfirmation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("AcceptedAt");

                    b.Property<string>("DeclinedAt")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 48)))
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("ExternalConfirmationId");

                    b.Property<int?>("TripId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TripId");

                    b.ToTable("Confirmations");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("ExternalEmployeeId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int?>("OfficeId");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbEmployeeAmenitiesChecklist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId");

                    b.Property<int?>("EmployeeId");

                    b.Property<int?>("FlightId");

                    b.Property<int?>("LivingPlaceId");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FlightId");

                    b.HasIndex("LivingPlaceId");

                    b.HasIndex("TripId");

                    b.ToTable("Checklists");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbEmployeeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DbEmployeeId");

                    b.Property<int?>("DbGroupId");

                    b.HasKey("Id");

                    b.HasIndex("DbEmployeeId");

                    b.HasIndex("DbGroupId");

                    b.ToTable("DbEmployeeGroup");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbEmployeePlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTimeOffset>("EndDate");

                    b.Property<DateTimeOffset>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeePlans");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExternalFileId");

                    b.Property<byte[]>("File");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DbTripId");

                    b.Property<string>("ExternalGroupId");

                    b.Property<int?>("ManagerId");

                    b.Property<int?>("StartingOfficeId");

                    b.HasKey("Id");

                    b.HasIndex("DbTripId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("StartingOfficeId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("DbApartmentId");

                    b.Property<string>("ExternalOfficeId");

                    b.HasKey("Id");

                    b.HasIndex("DbApartmentId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbRoomReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DateFrom");

                    b.Property<DateTimeOffset>("DateTo");

                    b.Property<int?>("EmployeeId");

                    b.Property<int?>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoomId");

                    b.ToTable("DbRoomReservations");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbTrip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DepartureDate");

                    b.Property<int?>("DestinationOfficeId");

                    b.Property<string>("ExternalTripId");

                    b.Property<DateTimeOffset>("ReturnDate");

                    b.Property<int?>("TripCreatorId");

                    b.HasKey("Id");

                    b.HasIndex("DestinationOfficeId");

                    b.HasIndex("TripCreatorId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.Reservations.DbCarReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarAddress");

                    b.Property<string>("CarNumber");

                    b.Property<DateTimeOffset?>("RentEndTime");

                    b.Property<DateTimeOffset?>("RentStartTime");

                    b.HasKey("Id");

                    b.ToTable("CarReservations");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.Reservations.DbFlightReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirportAddress");

                    b.Property<string>("Company");

                    b.Property<string>("FlightNumber");

                    b.Property<DateTimeOffset?>("FlightTime");

                    b.HasKey("Id");

                    b.ToTable("FlightReservations");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.Reservations.DbHotelReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("DateFrom");

                    b.Property<DateTimeOffset?>("DateTo");

                    b.Property<string>("HotelName");

                    b.HasKey("Id");

                    b.ToTable("HotelReservations");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.Amenities.DbCarRentAmenity", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.Reservations.DbCarReservation", "CarReservation")
                        .WithMany()
                        .HasForeignKey("CarReservationId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.Amenities.DbFlightAmenity", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.Reservations.DbFlightReservation", "FlightReservation")
                        .WithMany()
                        .HasForeignKey("FlightReservationId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.DbFile", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.Amenities.DbLivingPlaceAmenity", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbRoomReservation", "ApartmentRoomReservation")
                        .WithMany()
                        .HasForeignKey("ApartmentRoomReservationId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.Reservations.DbHotelReservation", "HotelReservation")
                        .WithMany()
                        .HasForeignKey("HotelReservationId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbApartmentRoom", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbApartment")
                        .WithMany("Rooms")
                        .HasForeignKey("DbApartmentId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbAuthorization", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbConfirmation", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.DbTrip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbEmployee", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbOffice", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbEmployeeAmenitiesChecklist", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.Amenities.DbCarRentAmenity", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.DbEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.Amenities.DbFlightAmenity", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.Amenities.DbLivingPlaceAmenity", "LivingPlace")
                        .WithMany()
                        .HasForeignKey("LivingPlaceId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.DbTrip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbEmployeeGroup", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbEmployee", "DbEmployee")
                        .WithMany()
                        .HasForeignKey("DbEmployeeId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.DbGroup", "DbGroup")
                        .WithMany()
                        .HasForeignKey("DbGroupId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbEmployeePlan", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbGroup", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbTrip")
                        .WithMany("Groups")
                        .HasForeignKey("DbTripId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.DbEmployee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.DbOffice", "StartingOffice")
                        .WithMany()
                        .HasForeignKey("StartingOfficeId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbOffice", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbApartment", "OfficeApartment")
                        .WithMany()
                        .HasForeignKey("DbApartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbRoomReservation", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.DbApartmentRoom", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("BackendApartmentReservation.Database.Entities.DbTrip", b =>
                {
                    b.HasOne("BackendApartmentReservation.Database.Entities.DbOffice", "DestinationOffice")
                        .WithMany()
                        .HasForeignKey("DestinationOfficeId");

                    b.HasOne("BackendApartmentReservation.Database.Entities.DbEmployee", "TripCreator")
                        .WithMany()
                        .HasForeignKey("TripCreatorId");
                });
#pragma warning restore 612, 618
        }
    }
}
