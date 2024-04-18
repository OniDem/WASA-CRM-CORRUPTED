using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeListTypeReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_receipts_ReceiptEntityId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ReceiptEntityId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ReceiptEntityId",
                table: "products");

            migrationBuilder.AddColumn<List<string>>(
                name: "Products",
                table: "receipts",
                type: "text[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Products",
                table: "receipts");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptEntityId",
                table: "products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ReceiptEntityId",
                table: "products",
                column: "ReceiptEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_receipts_ReceiptEntityId",
                table: "products",
                column: "ReceiptEntityId",
                principalTable: "receipts",
                principalColumn: "Id");
        }
    }
}
