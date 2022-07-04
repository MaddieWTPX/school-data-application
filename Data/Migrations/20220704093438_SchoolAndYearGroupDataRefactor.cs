using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDataApplication.Migrations
{
    public partial class SchoolAndYearGroupDataRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSchools");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ClassAssignments",
                columns: new[] { "ClassId", "UserId", "SchoolId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 1,
                column: "Address",
                value: "TPX Road, London, TPX 123, UK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "SchoolId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "SchoolId",
                value: 1);

            migrationBuilder.InsertData(
                table: "YearGroups",
                columns: new[] { "YearGroupId", "Name" },
                values: new object[,]
                {
                    { 4, "Year 4" },
                    { 5, "Year 5" },
                    { 6, "Year 6" },
                    { 7, "Year 7" },
                    { 8, "Year 8" },
                    { 9, "Year 9" },
                    { 10, "Year 10" },
                    { 11, "Year 11" },
                    { 12, "Year 12" },
                    { 13, "Year 13" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolId",
                table: "Users",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Schools_SchoolId",
                table: "Users",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Schools_SchoolId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SchoolId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserSchools",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSchools", x => new { x.UserId, x.SchoolId });
                    table.ForeignKey(
                        name: "FK_UserSchools_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSchools_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 1,
                column: "Address",
                value: "TPX, London, UK");

            migrationBuilder.InsertData(
                table: "UserSchools",
                columns: new[] { "SchoolId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserSchools_SchoolId",
                table: "UserSchools",
                column: "SchoolId");
        }
    }
}
