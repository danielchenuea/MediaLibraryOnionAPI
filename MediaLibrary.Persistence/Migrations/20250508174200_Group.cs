using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Group : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_MediaGroups_MediaGroupId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_MediaGroups_MediaGroupId",
                table: "VideoGames");

            migrationBuilder.RenameColumn(
                name: "MediaGroupId",
                table: "VideoGames",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoGames_MediaGroupId",
                table: "VideoGames",
                newName: "IX_VideoGames_GroupId");

            migrationBuilder.RenameColumn(
                name: "MediaGroupId",
                table: "Books",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_MediaGroupId",
                table: "Books",
                newName: "IX_Books_GroupId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_MediaGroups_GroupId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_MediaGroups_GroupId",
                table: "VideoGames");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "VideoGames",
                newName: "MediaGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoGames_GroupId",
                table: "VideoGames",
                newName: "IX_VideoGames_MediaGroupId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Books",
                newName: "MediaGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GroupId",
                table: "Books",
                newName: "IX_Books_MediaGroupId");

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
    }
}
