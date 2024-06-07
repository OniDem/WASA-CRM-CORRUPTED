using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddShiftEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loyaltyCards");

            migrationBuilder.CreateTable(
                name: "shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Closed = table.Column<bool>(type: "boolean", nullable: false),
                    OpenBy = table.Column<string>(type: "text", nullable: false),
                    ClosedBy = table.Column<string>(type: "text", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cash = table.Column<double>(type: "double precision", nullable: false),
                    Acquiring = table.Column<double>(type: "double precision", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false),
                    ReceiptsList = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shifts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shifts");

            migrationBuilder.CreateTable(
                name: "loyaltyCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Balance = table.Column<double>(type: "double precision", nullable: false),
                    BonusHistory = table.Column<List<double>>(type: "double precision[]", nullable: true),
                    HolderName = table.Column<string>(type: "text", nullable: false),
                    ReceiptIDs = table.Column<List<int>>(type: "integer[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loyaltyCards", x => x.Id);
                });
        }
    }
}
