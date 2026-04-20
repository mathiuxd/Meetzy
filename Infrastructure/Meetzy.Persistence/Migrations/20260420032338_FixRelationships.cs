using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meetzy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communities_Users_CreatorUserId",
                table: "Communities");

            migrationBuilder.DropIndex(
                name: "IX_Communities_CreatorUserId",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Communities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Communities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateIndex(
                name: "IX_Communities_CreatedBy",
                table: "Communities",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_Users_CreatedBy",
                table: "Communities",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Communities_Users_CreatedBy",
                table: "Communities");

            migrationBuilder.DropIndex(
                name: "IX_Communities_CreatedBy",
                table: "Communities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Communities",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorUserId",
                table: "Communities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Communities_CreatorUserId",
                table: "Communities",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Communities_Users_CreatorUserId",
                table: "Communities",
                column: "CreatorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
