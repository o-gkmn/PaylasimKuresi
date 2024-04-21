using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_relation_between_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_PostID",
                table: "PostLikes",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostLikes_UserID",
                table: "PostLikes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupID",
                table: "GroupUsers",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_UserID",
                table: "GroupUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_FounderID",
                table: "Groups",
                column: "FounderID");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowedPersonID",
                table: "Follows",
                column: "FollowedPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowingPersonID",
                table: "Follows",
                column: "FollowingPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Dms_ReceiverID",
                table: "Dms",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Dms_SenderID",
                table: "Dms",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityUsers_CommunityID",
                table: "CommunityUsers",
                column: "CommunityID");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityUsers_UserID",
                table: "CommunityUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Communities_FounderID",
                table: "Communities",
                column: "FounderID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_CommentID",
                table: "CommentLikes",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserID",
                table: "CommentLikes",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_AspNetUsers_UserID",
                table: "CommentLikes",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_Comments_CommentID",
                table: "CommentLikes",
                column: "CommentID",
                principalTable: "Comments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserID",
                table: "Comments",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostID",
                table: "Comments",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_AspNetUsers_FounderID",
                table: "Communities",
                column: "FounderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityUsers_AspNetUsers_UserID",
                table: "CommunityUsers",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityUsers_Communities_CommunityID",
                table: "CommunityUsers",
                column: "CommunityID",
                principalTable: "Communities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dms_AspNetUsers_ReceiverID",
                table: "Dms",
                column: "ReceiverID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dms_AspNetUsers_SenderID",
                table: "Dms",
                column: "SenderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowedPersonID",
                table: "Follows",
                column: "FollowedPersonID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowingPersonID",
                table: "Follows",
                column: "FollowingPersonID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_FounderID",
                table: "Groups",
                column: "FounderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_AspNetUsers_UserID",
                table: "GroupUsers",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_Groups_GroupID",
                table: "GroupUsers",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_AspNetUsers_UserID",
                table: "PostLikes",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_Posts_PostID",
                table: "PostLikes",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_AspNetUsers_UserID",
                table: "CommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_Comments_CommentID",
                table: "CommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Communities_AspNetUsers_FounderID",
                table: "Communities");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityUsers_AspNetUsers_UserID",
                table: "CommunityUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityUsers_Communities_CommunityID",
                table: "CommunityUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dms_AspNetUsers_ReceiverID",
                table: "Dms");

            migrationBuilder.DropForeignKey(
                name: "FK_Dms_AspNetUsers_SenderID",
                table: "Dms");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowedPersonID",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowingPersonID",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_FounderID",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_AspNetUsers_UserID",
                table: "GroupUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_Groups_GroupID",
                table: "GroupUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_AspNetUsers_UserID",
                table: "PostLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_Posts_PostID",
                table: "PostLikes");

            migrationBuilder.DropIndex(
                name: "IX_PostLikes_PostID",
                table: "PostLikes");

            migrationBuilder.DropIndex(
                name: "IX_PostLikes_UserID",
                table: "PostLikes");

            migrationBuilder.DropIndex(
                name: "IX_GroupUsers_GroupID",
                table: "GroupUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupUsers_UserID",
                table: "GroupUsers");

            migrationBuilder.DropIndex(
                name: "IX_Groups_FounderID",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FollowedPersonID",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FollowingPersonID",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Dms_ReceiverID",
                table: "Dms");

            migrationBuilder.DropIndex(
                name: "IX_Dms_SenderID",
                table: "Dms");

            migrationBuilder.DropIndex(
                name: "IX_CommunityUsers_CommunityID",
                table: "CommunityUsers");

            migrationBuilder.DropIndex(
                name: "IX_CommunityUsers_UserID",
                table: "CommunityUsers");

            migrationBuilder.DropIndex(
                name: "IX_Communities_FounderID",
                table: "Communities");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_CommentID",
                table: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_UserID",
                table: "CommentLikes");
        }
    }
}
