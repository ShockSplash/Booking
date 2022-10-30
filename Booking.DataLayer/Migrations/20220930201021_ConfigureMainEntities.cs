using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DataLayer.Migrations
{
    public partial class ConfigureMainEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:room_type", "economy,comfort,luxe")
                .Annotation("Npgsql:Enum:sex", "male,female")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
