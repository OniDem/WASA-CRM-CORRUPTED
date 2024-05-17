using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProjectTheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeLimitConfirmed",
                table: "receipts");

            migrationBuilder.DropColumn(
                name: "AgeLimit",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AgeLimitConfirmed",
                table: "receipts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AgeLimit",
                table: "products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "products",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
