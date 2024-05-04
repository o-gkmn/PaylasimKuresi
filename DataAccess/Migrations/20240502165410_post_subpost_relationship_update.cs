using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class post_subpost_relationship_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagePosts_Posts_PostID",
                table: "ImagePosts");

            migrationBuilder.DropForeignKey(
                name: "FK_TextPosts_Posts_PostID",
                table: "TextPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoPosts_Posts_PostID",
                table: "VideoPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_VoicePosts_Posts_PostID",
                table: "VoicePosts");

            migrationBuilder.DropIndex(
                name: "IX_VoicePosts_PostID",
                table: "VoicePosts");

            migrationBuilder.DropIndex(
                name: "IX_VideoPosts_PostID",
                table: "VideoPosts");

            migrationBuilder.DropIndex(
                name: "IX_TextPosts_PostID",
                table: "TextPosts");

            migrationBuilder.DropIndex(
                name: "IX_ImagePosts_PostID",
                table: "ImagePosts");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "VoicePosts");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "VideoPosts");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "TextPosts");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "ImagePosts");

            migrationBuilder.AddColumn<Guid>(
                name: "ImagePostID",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TextPostID",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VideoPostID",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VoicePostID",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ImagePostID",
                table: "Posts",
                column: "ImagePostID",
                unique: true,
                filter: "[ImagePostID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TextPostID",
                table: "Posts",
                column: "TextPostID",
                unique: true,
                filter: "[TextPostID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VideoPostID",
                table: "Posts",
                column: "VideoPostID",
                unique: true,
                filter: "[VideoPostID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VoicePostID",
                table: "Posts",
                column: "VoicePostID",
                unique: true,
                filter: "[VoicePostID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ImagePosts_ImagePostID",
                table: "Posts",
                column: "ImagePostID",
                principalTable: "ImagePosts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_TextPosts_TextPostID",
                table: "Posts",
                column: "TextPostID",
                principalTable: "TextPosts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_VideoPosts_VideoPostID",
                table: "Posts",
                column: "VideoPostID",
                principalTable: "VideoPosts",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_VoicePosts_VoicePostID",
                table: "Posts",
                column: "VoicePostID",
                principalTable: "VoicePosts",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ImagePosts_ImagePostID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_TextPosts_TextPostID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_VideoPosts_VideoPostID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_VoicePosts_VoicePostID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ImagePostID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TextPostID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_VideoPostID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_VoicePostID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImagePostID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TextPostID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "VideoPostID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "VoicePostID",
                table: "Posts");

            migrationBuilder.AddColumn<Guid>(
                name: "PostID",
                table: "VoicePosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostID",
                table: "VideoPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostID",
                table: "TextPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostID",
                table: "ImagePosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VoicePosts_PostID",
                table: "VoicePosts",
                column: "PostID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoPosts_PostID",
                table: "VideoPosts",
                column: "PostID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextPosts_PostID",
                table: "TextPosts",
                column: "PostID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagePosts_PostID",
                table: "ImagePosts",
                column: "PostID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagePosts_Posts_PostID",
                table: "ImagePosts",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextPosts_Posts_PostID",
                table: "TextPosts",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoPosts_Posts_PostID",
                table: "VideoPosts",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoicePosts_Posts_PostID",
                table: "VoicePosts",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
