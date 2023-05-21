using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DataLayer.Migrations
{
    public partial class AddCoords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Hotels",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Hotels",
                type: "double precision",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Hotels");
        }
    }
}
