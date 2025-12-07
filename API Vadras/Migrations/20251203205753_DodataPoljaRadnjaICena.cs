using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Vadras.Migrations
{
    /// <inheritdoc />
    public partial class DodataPoljaRadnjaICena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FinalnaCena",
                table: "StavkePorudzbine",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Radnja",
                table: "Porudzbine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalnaCena",
                table: "StavkePorudzbine");

            migrationBuilder.DropColumn(
                name: "Radnja",
                table: "Porudzbine");
        }
    }
}
