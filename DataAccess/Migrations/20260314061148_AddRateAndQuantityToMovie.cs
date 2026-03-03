using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema_APP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRateAndQuantityToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Movies");
        }
    }
}
