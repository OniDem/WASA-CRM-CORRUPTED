using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableInReceiptEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<double>>(
                name: "ProductPrices",
                table: "receipts",
                type: "double precision[]",
                nullable: true,
                oldClrType: typeof(List<double>),
                oldType: "double precision[]");

            migrationBuilder.AlterColumn<List<string>>(
                name: "ProductNames",
                table: "receipts",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "text[]");

            migrationBuilder.AlterColumn<List<double>>(
                name: "ProductCount",
                table: "receipts",
                type: "double precision[]",
                nullable: true,
                oldClrType: typeof(List<double>),
                oldType: "double precision[]");

            migrationBuilder.AlterColumn<List<string>>(
                name: "ProductCodes",
                table: "receipts",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(List<string>),
                oldType: "text[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<double>>(
                name: "ProductPrices",
                table: "receipts",
                type: "double precision[]",
                nullable: false,
                oldClrType: typeof(List<double>),
                oldType: "double precision[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<string>>(
                name: "ProductNames",
                table: "receipts",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<double>>(
                name: "ProductCount",
                table: "receipts",
                type: "double precision[]",
                nullable: false,
                oldClrType: typeof(List<double>),
                oldType: "double precision[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<string>>(
                name: "ProductCodes",
                table: "receipts",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(List<string>),
                oldType: "text[]",
                oldNullable: true);
        }
    }
}
