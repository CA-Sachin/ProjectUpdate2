using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectUpdateApp.Migrations
{
    /// <inheritdoc />
    public partial class dgg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectUpdate",
                table: "ProjectUpdate");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ProjectUpdate",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectUpdate",
                table: "ProjectUpdate",
                column: "ProjectUpdateID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUpdate_UserId",
                table: "ProjectUpdate",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUpdate_User_UserId",
                table: "ProjectUpdate",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUpdate_User_UserId",
                table: "ProjectUpdate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectUpdate",
                table: "ProjectUpdate");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUpdate_UserId",
                table: "ProjectUpdate");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProjectUpdate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectUpdate",
                table: "ProjectUpdate",
                columns: new[] { "ProjectUpdateID", "Id" });
        }
    }
}
