using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectUpdateApp.Migrations
{
    /// <inheritdoc />
    public partial class gf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUpdate_User_Id",
                table: "ProjectUpdate");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUpdate_User_UserId",
                table: "ProjectUpdate");

            migrationBuilder.DropTable(
                name: "UserProject");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUpdate_Id",
                table: "ProjectUpdate");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUpdate_UserId",
                table: "ProjectUpdate");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectUpdate");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProjectUpdate");

            migrationBuilder.CreateTable(
                name: "UserProjectUpdate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjectUpdate", x => new { x.ProjectUpdateID, x.Id });
                    table.ForeignKey(
                        name: "FK_UserProjectUpdate_ProjectUpdate_ProjectUpdateID",
                        column: x => x.ProjectUpdateID,
                        principalTable: "ProjectUpdate",
                        principalColumn: "ProjectUpdateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjectUpdate_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectUpdate_Id",
                table: "UserProjectUpdate",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProjectUpdate");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProjectUpdate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ProjectUpdate",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProject_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProject_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUpdate_Id",
                table: "ProjectUpdate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUpdate_UserId",
                table: "ProjectUpdate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectID",
                table: "UserProject",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_UserId",
                table: "UserProject",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUpdate_User_Id",
                table: "ProjectUpdate",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUpdate_User_UserId",
                table: "ProjectUpdate",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
