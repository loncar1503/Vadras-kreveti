using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Vadras.Migrations
{
    /// <inheritdoc />
    public partial class dodavanjeDimenzije : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimenzije",
                table: "Proizvodi");

            migrationBuilder.AddColumn<string>(
                name: "Dimenzija",
                table: "StavkePorudzbine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimenzija",
                table: "StavkePorudzbine");

            migrationBuilder.AddColumn<string>(
                name: "Dimenzije",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
