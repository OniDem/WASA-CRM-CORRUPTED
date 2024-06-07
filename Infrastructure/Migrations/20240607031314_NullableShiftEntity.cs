using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NullableShiftEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "shifts",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<List<int>>(
                name: "ReceiptsList",
                table: "shifts",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(List<int>),
                oldType: "integer[]");

            migrationBuilder.AlterColumn<string>(
                name: "ClosedBy",
                table: "shifts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "Closed",
                table: "shifts",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "shifts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<double>(
                name: "Cash",
                table: "shifts",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "Acquiring",
                table: "shifts",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.CreateIndex(
                name: "IX_shifts_Acquiring",
                table: "shifts",
                column: "Acquiring")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_Cash",
                table: "shifts",
                column: "Cash")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_Closed",
                table: "shifts",
                column: "Closed")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_CloseDate",
                table: "shifts",
                column: "CloseDate")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_ClosedBy",
                table: "shifts",
                column: "ClosedBy")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_ReceiptsList",
                table: "shifts",
                column: "ReceiptsList")
                .Annotation("Npgsql:NullsDistinct", true);

            migrationBuilder.CreateIndex(
                name: "IX_shifts_Total",
                table: "shifts",
                column: "Total")
                .Annotation("Npgsql:NullsDistinct", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_shifts_Acquiring",
                table: "shifts");

            migrationBuilder.DropIndex(
                name: "IX_shifts_Cash",
                table: "shifts");

            migrationBuilder.DropIndex(
                name: "IX_shifts_Closed",
                table: "shifts");

            migrationBuilder.DropIndex(
                name: "IX_shifts_CloseDate",
                table: "shifts");

            migrationBuilder.DropIndex(
                name: "IX_shifts_ClosedBy",
                table: "shifts");

            migrationBuilder.DropIndex(
                name: "IX_shifts_ReceiptsList",
                table: "shifts");

            migrationBuilder.DropIndex(
                name: "IX_shifts_Total",
                table: "shifts");

            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "shifts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<List<int>>(
                name: "ReceiptsList",
                table: "shifts",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(List<int>),
                oldType: "integer[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClosedBy",
                table: "shifts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Closed",
                table: "shifts",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "shifts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Cash",
                table: "shifts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Acquiring",
                table: "shifts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }
    }
}
