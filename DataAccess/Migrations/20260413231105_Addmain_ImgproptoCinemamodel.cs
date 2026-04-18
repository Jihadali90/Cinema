using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema_APP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Addmain_ImgproptoCinemamodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Main_Img",
                table: "Cinemas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Main_Img",
                table: "Cinemas");
        }
    }
}
