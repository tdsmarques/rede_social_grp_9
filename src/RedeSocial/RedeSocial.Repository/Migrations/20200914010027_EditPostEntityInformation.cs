using Microsoft.EntityFrameworkCore.Migrations;

namespace RedeSocial.Repository.Migrations
{
    public partial class EditPostEntityInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserImageUrl",
                table: "Post",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Post",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImageUrl",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "Post");
        }
    }
}
