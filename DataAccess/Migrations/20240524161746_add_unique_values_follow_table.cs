using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_unique_values_follow_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FollowingPersonID",
                table: "Follows");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowingPersonID_FollowedPersonID",
                table: "Follows",
                columns: new[] { "FollowingPersonID", "FollowedPersonID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostID",
                table: "Comments",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FollowingPersonID_FollowedPersonID",
                table: "Follows");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowingPersonID",
                table: "Follows",
                column: "FollowingPersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostID",
                table: "Comments",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
