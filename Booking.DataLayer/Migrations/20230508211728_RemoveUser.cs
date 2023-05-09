using System;
using Booking.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.DataLayer.Migrations
{
    public partial class RemoveUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1mc()"),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Email = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    FullName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Login = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Password = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Sex = table.Column<Sex>(type: "sex", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
