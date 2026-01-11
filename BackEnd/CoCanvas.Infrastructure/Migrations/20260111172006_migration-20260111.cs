using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoCanvas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration20260111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "app",
                table: "Critiques",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "app",
                table: "Critiques");
        }
    }
}
