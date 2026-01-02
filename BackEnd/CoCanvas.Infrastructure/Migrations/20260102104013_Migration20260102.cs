using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoCanvas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration20260102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comments_CommentId",
                schema: "app",
                table: "Replies");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                schema: "app",
                table: "Replies",
                newName: "CritiqueId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_CommentId",
                schema: "app",
                table: "Replies",
                newName: "IX_Replies_CritiqueId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "app",
                table: "Replies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "app",
                table: "Critiques",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "app",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CritiqueCanvases",
                schema: "app",
                columns: table => new
                {
                    CritiqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanvasJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CritiqueCanvases", x => x.CritiqueId);
                    table.ForeignKey(
                        name: "FK_CritiqueCanvases_Critiques_CritiqueId",
                        column: x => x.CritiqueId,
                        principalSchema: "app",
                        principalTable: "Critiques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Critiques_CritiqueId",
                schema: "app",
                table: "Replies",
                column: "CritiqueId",
                principalSchema: "app",
                principalTable: "Critiques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Critiques_CritiqueId",
                schema: "app",
                table: "Replies");

            migrationBuilder.DropTable(
                name: "CritiqueCanvases",
                schema: "app");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "app",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "app",
                table: "Critiques");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "app",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CritiqueId",
                schema: "app",
                table: "Replies",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_CritiqueId",
                schema: "app",
                table: "Replies",
                newName: "IX_Replies_CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comments_CommentId",
                schema: "app",
                table: "Replies",
                column: "CommentId",
                principalSchema: "app",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
