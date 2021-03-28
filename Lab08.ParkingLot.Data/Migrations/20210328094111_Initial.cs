using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab08.ParkingLot.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lab08");

            migrationBuilder.CreateTable(
                name: "Vehicle",
                schema: "Lab08",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    DiscountCard = table.Column<int>(nullable: false),
                    VehicleCategory = table.Column<int>(nullable: false),
                    EntryTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_VehicleId", x => x.VehicleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Number",
                schema: "Lab08",
                table: "Vehicle",
                column: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle",
                schema: "Lab08");
        }
    }
}
