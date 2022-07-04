using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDataApplication.Migrations
{
    public partial class SeedSecondaryData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 1,
                column: "ClassDescription",
                value: "Modern Foreign Languages");

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 2,
                column: "ClassDescription",
                value: "Modern Foreign Languages");

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 3,
                column: "ClassDescription",
                value: "STEM");

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 4,
                column: "ClassDescription",
                value: "STEM");

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 5,
                column: "ClassDescription",
                value: "STEM");

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 6,
                column: "ClassDescription",
                value: "STEM");

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 7,
                column: "ClassDescription",
                value: "Humanities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 1,
                column: "ClassDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 2,
                column: "ClassDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 3,
                column: "ClassDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 4,
                column: "ClassDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 5,
                column: "ClassDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 6,
                column: "ClassDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 7,
                column: "ClassDescription",
                value: null);
        }
    }
}
