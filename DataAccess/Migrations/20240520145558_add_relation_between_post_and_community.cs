using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_relation_between_post_and_community : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Posts_CommunityID",
                table: "Posts",
                column: "CommunityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Communities_CommunityID",
                table: "Posts",
                column: "CommunityID",
                principalTable: "Communities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Communities_CommunityID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CommunityID",
                table: "Posts");
        }
    }
}
