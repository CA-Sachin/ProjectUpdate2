using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectUpdateApp.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectUpdate",
                columns: table => new
                {
                    ProjectUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaskDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Workinghrs = table.Column<int>(type: "int", nullable: false),
                    Billinghrs = table.Column<int>(type: "int", nullable: false),
                    NextPlan = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reasonoflessbilling = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUpdate", x => x.ProjectUpdateID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

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
                name: "Role");

            migrationBuilder.DropTable(
                name: "UserProjectUpdate");

            migrationBuilder.DropTable(
                name: "ProjectUpdate");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
