using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spoonbill.Migrations
{
    /// <inheritdoc />
    public partial class PersonAndAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "PERSON");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PERSON",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PERSON",
                newName: "person_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "date_of_birth",
                table: "PERSON",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "surname",
                table: "PERSON",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PERSON",
                table: "PERSON",
                column: "person_id");

            migrationBuilder.CreateTable(
                name: "ADDRESSES",
                columns: table => new
                {
                    address = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    person_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESSES", x => new { x.address, x.person_id });
                    table.ForeignKey(
                        name: "FK_ADDRESSES_PERSON_person_id",
                        column: x => x.person_id,
                        principalTable: "PERSON",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PHONENUMBERS",
                columns: table => new
                {
                    phone_number = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    person_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHONENUMBERS", x => new { x.person_id, x.phone_number });
                    table.ForeignKey(
                        name: "FK_PHONENUMBERS_PERSON_person_id",
                        column: x => x.person_id,
                        principalTable: "PERSON",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_person_id",
                table: "ADDRESSES",
                column: "person_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADDRESSES");

            migrationBuilder.DropTable(
                name: "PHONENUMBERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PERSON",
                table: "PERSON");

            migrationBuilder.DropColumn(
                name: "date_of_birth",
                table: "PERSON");

            migrationBuilder.DropColumn(
                name: "surname",
                table: "PERSON");

            migrationBuilder.RenameTable(
                name: "PERSON",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "People",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "People",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_PersonId",
                table: "Passengers",
                column: "PersonId");
        }
    }
}
