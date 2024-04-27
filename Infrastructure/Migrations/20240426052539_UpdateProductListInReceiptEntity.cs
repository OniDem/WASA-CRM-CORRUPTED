using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductListInReceiptEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Products",
                table: "receipts",
                newName: "ProductCodes");

            migrationBuilder.AddColumn<int?[]>(
                name: "ProductCategories",
                table: "receipts",
                type: "integer[]",
                nullable: false,
                defaultValue: new int?[0]);

            migrationBuilder.AddColumn<List<double?>>(
                name: "ProductCount",
                table: "receipts",
                type: "double precision[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "ProductNames",
                table: "receipts",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<List<double?>>(
                name: "ProductPrices",
                table: "receipts",
                type: "double precision[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCategories",
                table: "receipts");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "receipts");

            migrationBuilder.DropColumn(
                name: "ProductNames",
                table: "receipts");

            migrationBuilder.DropColumn(
                name: "ProductPrices",
                table: "receipts");

            migrationBuilder.RenameColumn(
                name: "ProductCodes",
                table: "receipts",
                newName: "Products");
        }
    }
}
