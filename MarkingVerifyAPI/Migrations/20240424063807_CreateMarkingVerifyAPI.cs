using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkingVerifyAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateMarkingVerifyAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alcohollabels",
                columns: table => new
                {
                    Label = table.Column<string>(type: "text", nullable: false),
                    AlcoholCode = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Volume = table.Column<double>(type: "double precision", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alcohollabels", x => x.Label);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alcohollabels_Label",
                table: "alcohollabels",
                column: "Label",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alcohollabels");
        }
    }
}
