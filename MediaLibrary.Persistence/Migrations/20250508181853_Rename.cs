using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_MediaGroups_GroupId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_MediaGroups_GroupId",
                table: "VideoGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaGroups",
                table: "MediaGroups");

            migrationBuilder.RenameTable(
                name: "MediaGroups",
                newName: "Groups");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEdit",
                table: "Groups",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateInsert",
                table: "Groups",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Groups_GroupId",
                table: "Books",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Groups_GroupId",
                table: "VideoGames",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Groups_GroupId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Groups_GroupId",
                table: "VideoGames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DateEdit",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DateInsert",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "MediaGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaGroups",
                table: "MediaGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_MediaGroups_GroupId",
                table: "Books",
                column: "GroupId",
                principalTable: "MediaGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_MediaGroups_GroupId",
                table: "VideoGames",
                column: "GroupId",
                principalTable: "MediaGroups",
                principalColumn: "Id");
        }
    }
}
