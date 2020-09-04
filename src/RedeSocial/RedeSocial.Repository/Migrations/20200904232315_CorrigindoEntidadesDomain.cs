using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedeSocial.Repository.Migrations
{
    public partial class CorrigindoEntidadesDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Profile_ProfileId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Profile_ProfileId1",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_ProfileId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_ProfileId1",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ProfileId1",
                table: "Account");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId1",
                table: "Account",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Profile_RoleId",
                table: "Account",
                column: "RoleId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Profile_RoleId1",
                table: "Account",
                column: "RoleId1",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Profile_RoleId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Profile_RoleId1",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_RoleId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_RoleId1",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Account");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "Account",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId1",
                table: "Account",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_ProfileId",
                table: "Account",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_ProfileId1",
                table: "Account",
                column: "ProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Profile_ProfileId",
                table: "Account",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Profile_ProfileId1",
                table: "Account",
                column: "ProfileId1",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
