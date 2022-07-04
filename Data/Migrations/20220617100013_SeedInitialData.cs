using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDataApplication.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SchoolClasses",
                columns: new[] { "ClassId", "ClassDescription", "ClassName" },
                values: new object[,]
                {
                    { 1, null, "French" },
                    { 2, null, "Italian" },
                    { 3, null, "Mathematics" },
                    { 4, null, "Chemistry" },
                    { 5, null, "Physics" },
                    { 6, null, "Biology" },
                    { 7, null, "Literature" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Teacher" },
                    { 2, "Student" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
