using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNetSocialMedia.Data.Migrations
{
    public partial class FriendshipUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FriendName",
                table: "FriendRelation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CloseFriendName",
                table: "CloseFriendRelation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendName",
                table: "FriendRelation");

            migrationBuilder.DropColumn(
                name: "CloseFriendName",
                table: "CloseFriendRelation");
        }
    }
}
