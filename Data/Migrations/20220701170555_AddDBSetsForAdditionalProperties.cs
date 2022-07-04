using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDataApplication.Migrations
{
    public partial class AddDBSetsForAdditionalProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_YearGroup_YearGroupId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSchool_School_SchoolId",
                table: "UserSchool");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSchool_Users_UserId",
                table: "UserSchool");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YearGroup",
                table: "YearGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSchool",
                table: "UserSchool");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School",
                table: "School");

            migrationBuilder.RenameTable(
                name: "YearGroup",
                newName: "YearGroups");

            migrationBuilder.RenameTable(
                name: "UserSchool",
                newName: "UserSchools");

            migrationBuilder.RenameTable(
                name: "School",
                newName: "Schools");

            migrationBuilder.RenameIndex(
                name: "IX_UserSchool_SchoolId",
                table: "UserSchools",
                newName: "IX_UserSchools_SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YearGroups",
                table: "YearGroups",
                column: "YearGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSchools",
                table: "UserSchools",
                columns: new[] { "UserId", "SchoolId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_YearGroups_YearGroupId",
                table: "Users",
                column: "YearGroupId",
                principalTable: "YearGroups",
                principalColumn: "YearGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchools_Schools_SchoolId",
                table: "UserSchools",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchools_Users_UserId",
                table: "UserSchools",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_YearGroups_YearGroupId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSchools_Schools_SchoolId",
                table: "UserSchools");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSchools_Users_UserId",
                table: "UserSchools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YearGroups",
                table: "YearGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSchools",
                table: "UserSchools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.RenameTable(
                name: "YearGroups",
                newName: "YearGroup");

            migrationBuilder.RenameTable(
                name: "UserSchools",
                newName: "UserSchool");

            migrationBuilder.RenameTable(
                name: "Schools",
                newName: "School");

            migrationBuilder.RenameIndex(
                name: "IX_UserSchools_SchoolId",
                table: "UserSchool",
                newName: "IX_UserSchool_SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YearGroup",
                table: "YearGroup",
                column: "YearGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSchool",
                table: "UserSchool",
                columns: new[] { "UserId", "SchoolId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_School",
                table: "School",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_YearGroup_YearGroupId",
                table: "Users",
                column: "YearGroupId",
                principalTable: "YearGroup",
                principalColumn: "YearGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchool_School_SchoolId",
                table: "UserSchool",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchool_Users_UserId",
                table: "UserSchool",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
