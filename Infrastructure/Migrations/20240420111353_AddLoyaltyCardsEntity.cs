using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLoyaltyCardsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LoyaltyBonusAdded",
                table: "receipts",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoyaltyCardID",
                table: "receipts",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoyaltyBonusAdded",
                table: "receipts");

            migrationBuilder.DropColumn(
                name: "LoyaltyCardID",
                table: "receipts");
        }
    }
}
