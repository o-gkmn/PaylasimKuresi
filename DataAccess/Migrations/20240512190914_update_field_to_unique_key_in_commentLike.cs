using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update_field_to_unique_key_in_commentLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_UserID",
                table: "CommentLikes");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserID_CommentID",
                table: "CommentLikes",
                columns: new[] { "UserID", "CommentID" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_UserID_CommentID",
                table: "CommentLikes");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserID",
                table: "CommentLikes",
                column: "UserID");
        }
    }
}
