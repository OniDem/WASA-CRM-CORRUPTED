using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOperationsShiftEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AcquiringApproved",
                table: "shifts",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CashBox",
                table: "shifts",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "CashBoxOperations",
                table: "shifts",
                type: "text[]",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_AcquiringApproved",
                table: "shifts",
                column: "AcquiringApproved")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_CashBox",
                table: "shifts",
                column: "CashBox")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_CashBoxOperations",
                table: "shifts",
                column: "CashBoxOperations")
                .Annotation("Npgsql:NullsDistinct", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_shifts_AcquiringApproved",
                table: "shifts");

            migrationBuilder.DropIndex(
                name: "IX_shifts_CashBox",
                table: "shifts");

            migrationBuilder.DropIndex(
                name: "IX_shifts_CashBoxOperations",
                table: "shifts");

            migrationBuilder.DropColumn(
                name: "AcquiringApproved",
                table: "shifts");

            migrationBuilder.DropColumn(
                name: "CashBox",
                table: "shifts");

            migrationBuilder.DropColumn(
                name: "CashBoxOperations",
                table: "shifts");
        }
    }
}
