using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDataApplication.Migrations
{
    public partial class AdditionalUserPropertiesAndRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "School",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "YearGroup",
                table: "Users",
                newName: "YearGroupId");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "ClassAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "YearGroup",
                columns: table => new
                {
                    YearGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearGroup", x => x.YearGroupId);
                });

            migrationBuilder.CreateTable(
                name: "UserSchool",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSchool", x => new { x.UserId, x.SchoolId });
                    table.ForeignKey(
                        name: "FK_UserSchool_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSchool_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "SchoolId", "Address", "Name" },
                values: new object[] { 1, "TPX, London, UK", "TPXImpact School" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "FirstName", "LastName", "UserTypeId", "YearGroupId" },
                values: new object[] { 1, null, "Ben", "Sztucki", 1, null });

            migrationBuilder.InsertData(
                table: "YearGroup",
                columns: new[] { "YearGroupId", "Name" },
                values: new object[,]
                {
                    { 1, "Year 1" },
                    { 2, "Year 2" },
                    { 3, "Year 3" }
                });

            migrationBuilder.InsertData(
                table: "UserSchool",
                columns: new[] { "SchoolId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "FirstName", "LastName", "UserTypeId", "YearGroupId" },
                values: new object[] { 2, null, "Madeleine", "Williams", 2, 1 });

            migrationBuilder.InsertData(
                table: "ClassAssignments",
                columns: new[] { "ClassId", "UserId", "SchoolId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "ClassAssignments",
                columns: new[] { "ClassId", "UserId", "SchoolId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_YearGroupId",
                table: "Users",
                column: "YearGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSchool_SchoolId",
                table: "UserSchool",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_YearGroup_YearGroupId",
                table: "Users",
                column: "YearGroupId",
                principalTable: "YearGroup",
                principalColumn: "YearGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_YearGroup_YearGroupId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserSchool");

            migrationBuilder.DropTable(
                name: "YearGroup");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropIndex(
                name: "IX_Users_YearGroupId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "ClassAssignments");

            migrationBuilder.RenameColumn(
                name: "YearGroupId",
                table: "Users",
                newName: "YearGroup");

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Users",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "TPXSchool");
        }
    }
}
