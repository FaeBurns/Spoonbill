using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spoonbill.Wpf.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeRating = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffWorkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffWorkers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountyName = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Cities_Counties_CountyName",
                        column: x => x.CountyName,
                        principalTable: "Counties",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Airports_Cities_CityName",
                        column: x => x.CityName,
                        principalTable: "Cities",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Cities_CityName",
                        column: x => x.CityName,
                        principalTable: "Cities",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaneModels",
                columns: table => new
                {
                    ModelNumber = table.Column<int>(type: "int", nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TypeRating = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneModels", x => x.ModelNumber);
                    table.ForeignKey(
                        name: "FK_PlaneModels_Manufacturers_ManufacturerName",
                        column: x => x.ManufacturerName,
                        principalTable: "Manufacturers",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Serial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ModelNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Serial);
                    table.ForeignKey(
                        name: "FK_Planes_PlaneModels_ModelNumber",
                        column: x => x.ModelNumber,
                        principalTable: "PlaneModels",
                        principalColumn: "ModelNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneSerial = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Planes_PlaneSerial",
                        column: x => x.PlaneSerial,
                        principalTable: "Planes",
                        principalColumn: "Serial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightPassenger",
                columns: table => new
                {
                    FlightsFlightId = table.Column<int>(type: "int", nullable: false),
                    PassengersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPassenger", x => new { x.FlightsFlightId, x.PassengersId });
                    table.ForeignKey(
                        name: "FK_FlightPassenger_Flights_FlightsFlightId",
                        column: x => x.FlightsFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightPassenger_Passengers_PassengersId",
                        column: x => x.PassengersId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightPilot",
                columns: table => new
                {
                    AssignedFlightsFlightId = table.Column<int>(type: "int", nullable: false),
                    PilotsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPilot", x => new { x.AssignedFlightsFlightId, x.PilotsId });
                    table.ForeignKey(
                        name: "FK_FlightPilot_Flights_AssignedFlightsFlightId",
                        column: x => x.AssignedFlightsFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightPilot_Pilots_PilotsId",
                        column: x => x.PilotsId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightStaffWorker",
                columns: table => new
                {
                    AssignedFlightsFlightId = table.Column<int>(type: "int", nullable: false),
                    WorkerStaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightStaffWorker", x => new { x.AssignedFlightsFlightId, x.WorkerStaffId });
                    table.ForeignKey(
                        name: "FK_FlightStaffWorker_Flights_AssignedFlightsFlightId",
                        column: x => x.AssignedFlightsFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightStaffWorker_StaffWorkers_WorkerStaffId",
                        column: x => x.WorkerStaffId,
                        principalTable: "StaffWorkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stops_Airports_AirportName",
                        column: x => x.AirportName,
                        principalTable: "Airports",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stops_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_CityName",
                table: "Airports",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountyName",
                table: "Cities",
                column: "CountyName");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_PassengersId",
                table: "FlightPassenger",
                column: "PassengersId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPilot_PilotsId",
                table: "FlightPilot",
                column: "PilotsId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneSerial",
                table: "Flights",
                column: "PlaneSerial");

            migrationBuilder.CreateIndex(
                name: "IX_FlightStaffWorker_WorkerStaffId",
                table: "FlightStaffWorker",
                column: "WorkerStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_CityName",
                table: "Manufacturers",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneModels_ManufacturerName",
                table: "PlaneModels",
                column: "ManufacturerName");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_ModelNumber",
                table: "Planes",
                column: "ModelNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Stops_AirportName",
                table: "Stops",
                column: "AirportName");

            migrationBuilder.CreateIndex(
                name: "IX_Stops_FlightId",
                table: "Stops",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightPassenger");

            migrationBuilder.DropTable(
                name: "FlightPilot");

            migrationBuilder.DropTable(
                name: "FlightStaffWorker");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "StaffWorkers");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "PlaneModels");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Counties");
        }
    }
}
