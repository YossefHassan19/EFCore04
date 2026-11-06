using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore04.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "hassan.mahmoud@nbg.com", "Hassan Mahmoud", new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01011112222" },
                    { 2, "salma.adel@nbg.com", "Salma Adel", new DateTime(2018, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01022223333" },
                    { 3, "omar.khaled@nbg.com", "Omar Khaled", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01033334444" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "ManagerId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "ALX-01", "5 Corniche Road, Alexandria", 2, "Alexandria Branch", "0345000002" },
                    { "CAI-01", "10 Tahrir Square, Cairo", 1, "Cairo Main Branch", "0227000001" },
                    { "GIZ-01", "22 Pyramids Street, Giza", 3, "Giza Branch", "0233000003" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "ALX-01");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "CAI-01");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "GIZ-01");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
