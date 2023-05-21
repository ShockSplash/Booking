using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DataLayer.Migrations
{
    public partial class AddRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Hotels",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Hotels");
        }
    }
}
