using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoCanvas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration20260102_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                schema: "app",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                schema: "app",
                table: "Posts");
        }
    }
}
