using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Library : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "VideoGames",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "HoursPlayed",
                table: "VideoGames",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaused",
                table: "VideoGames",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlaying",
                table: "VideoGames",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MediaGroupId",
                table: "VideoGames",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tags",
                table: "VideoGames",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaused",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReading",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MediaGroupId",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MediaGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GroupTitle = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_MediaGroupId",
                table: "VideoGames",
                column: "MediaGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_MediaGroupId",
                table: "Books",
                column: "MediaGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_MediaGroups_MediaGroupId",
                table: "Books",
                column: "MediaGroupId",
                principalTable: "MediaGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_MediaGroups_MediaGroupId",
                table: "VideoGames",
                column: "MediaGroupId",
                principalTable: "MediaGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_MediaGroups_MediaGroupId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_MediaGroups_MediaGroupId",
                table: "VideoGames");

            migrationBuilder.DropTable(
                name: "MediaGroups");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_MediaGroupId",
                table: "VideoGames");

            migrationBuilder.DropIndex(
                name: "IX_Books_MediaGroupId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "HoursPlayed",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "IsPaused",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "IsPlaying",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "MediaGroupId",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsPaused",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsReading",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "MediaGroupId",
                table: "Books");
        }
    }
}
