using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkingVerifyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMilkLabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "milklabels",
                columns: table => new
                {
                    Label = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Volume = table.Column<double>(type: "double precision", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoursToExpiration = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_milklabels", x => x.Label);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "milklabels");
        }
    }
}
