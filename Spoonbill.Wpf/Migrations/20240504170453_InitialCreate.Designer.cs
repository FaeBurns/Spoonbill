﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spoonbill.Wpf.Data;

#nullable disable

namespace Spoonbill.Wpf.Migrations
{
    [DbContext(typeof(SpoonbillContext))]
    [Migration("20240504170453_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.Property<int>("FlightsFlightId")
                        .HasColumnType("int");

                    b.Property<int>("PassengersId")
                        .HasColumnType("int");

                    b.HasKey("FlightsFlightId", "PassengersId");

                    b.HasIndex("PassengersId");

                    b.ToTable("FlightPassenger");
                });

            modelBuilder.Entity("FlightPilot", b =>
                {
                    b.Property<int>("AssignedFlightsFlightId")
                        .HasColumnType("int");

                    b.Property<int>("PilotsId")
                        .HasColumnType("int");

                    b.HasKey("AssignedFlightsFlightId", "PilotsId");

                    b.HasIndex("PilotsId");

                    b.ToTable("FlightPilot");
                });

            modelBuilder.Entity("FlightStaffWorker", b =>
                {
                    b.Property<int>("AssignedFlightsFlightId")
                        .HasColumnType("int");

                    b.Property<int>("WorkerStaffId")
                        .HasColumnType("int");

                    b.HasKey("AssignedFlightsFlightId", "WorkerStaffId");

                    b.HasIndex("WorkerStaffId");

                    b.ToTable("FlightStaffWorker");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Airport", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Name");

                    b.HasIndex("CityName");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.City", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CountyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Name");

                    b.HasIndex("CountyName");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.County", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Name");

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PlaneSerial")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("FlightId");

                    b.HasIndex("PlaneSerial");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.FlightStop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirportName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirportName");

                    b.HasIndex("FlightId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Manufacturer", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Name");

                    b.HasIndex("CityName");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Pilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Salary")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TypeRating")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Plane", b =>
                {
                    b.Property<string>("Serial")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ModelNumber")
                        .HasColumnType("int");

                    b.HasKey("Serial");

                    b.HasIndex("ModelNumber");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.PlaneModel", b =>
                {
                    b.Property<int>("ModelNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeRating")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ModelNumber");

                    b.HasIndex("ManufacturerName");

                    b.ToTable("PlaneModels");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.StaffWorker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Salary")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("StaffWorkers");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.HasOne("Spoonbill.Wpf.Data.Models.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightsFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spoonbill.Wpf.Data.Models.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightPilot", b =>
                {
                    b.HasOne("Spoonbill.Wpf.Data.Models.Flight", null)
                        .WithMany()
                        .HasForeignKey("AssignedFlightsFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spoonbill.Wpf.Data.Models.Pilot", null)
                        .WithMany()
                        .HasForeignKey("PilotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlightStaffWorker", b =>
                {
                    b.HasOne("Spoonbill.Wpf.Data.Models.Flight", null)
                        .WithMany()
                        .HasForeignKey("AssignedFlightsFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spoonbill.Wpf.Data.Models.StaffWorker", null)
                        .WithMany()
                        .HasForeignKey("WorkerStaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Airport", b =>
                {
                    b.HasOne("Spoonbill.Wpf.Data.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.City", b =>
                {
                    b.HasOne("Spoonbill.Wpf.Data.Models.County", "County")
                        .WithMany()
                        .HasForeignKey("CountyName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("County");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Flight", b =>
                {
                    b.HasOne("Spoonbill.Wpf.Data.Models.Plane", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneSerial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.FlightStop", b =>
                {
                    b.HasOne("Spoonbill.Wpf.Data.Models.Airport", "Airport")
                        .WithMany()
                        .HasForeignKey("AirportName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spoonbill.Wpf.Data.Models.Flight", null)
                        .WithMany("Stops")
                        .HasForeignKey("FlightId");

                    b.Navigation("Airport");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Manufacturer", b =>
                {
                    b.HasOne("Spoonbill.Wpf.Data.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Plane", b =>
                {
                    b.HasOne("Spoonbill.Wpf.Data.Models.PlaneModel", "Model")
                        .WithMany()
                        .HasForeignKey("ModelNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.PlaneModel", b =>
                {
                    b.HasOne("Spoonbill.Wpf.Data.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Spoonbill.Wpf.Data.Models.Flight", b =>
                {
                    b.Navigation("Stops");
                });
#pragma warning restore 612, 618
        }
    }
}
