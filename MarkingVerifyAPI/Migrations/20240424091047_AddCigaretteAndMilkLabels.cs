using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkingVerifyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCigaretteAndMilkLabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cigarettelabels",
                columns: table => new
                {
                    Label = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cigarettelabels", x => x.Label);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cigarettelabels_Label",
                table: "cigarettelabels",
                column: "Label",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cigarettelabels");
        }
    }
}
