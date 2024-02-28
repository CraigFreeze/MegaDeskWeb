using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDeskWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAllAddServieFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Material",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "DeskQuote",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
