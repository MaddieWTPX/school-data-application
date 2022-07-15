using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDataApplication.Migrations
{
    public partial class RemoveAllSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 2 });

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
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SchoolClasses",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "UserTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "YearGroups",
                keyColumn: "YearGroupId",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SchoolClasses",
                columns: new[] { "ClassId", "ClassDescription", "ClassName" },
                values: new object[,]
                {
                    { 1, "Modern Foreign Languages", "French" },
                    { 2, "Modern Foreign Languages", "Italian" },
                    { 3, "STEM", "Mathematics" },
                    { 4, "STEM", "Chemistry" },
                    { 5, "STEM", "Physics" },
                    { 6, "STEM", "Biology" },
                    { 7, "Humanities", "Literature" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "SchoolId", "Address", "Name" },
                values: new object[] { 1, "TPX Road, London, TPX 123, UK", "TPXImpact School" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Teacher" },
                    { 2, "Student" }
                });

            migrationBuilder.InsertData(
                table: "YearGroups",
                columns: new[] { "YearGroupId", "Name" },
                values: new object[,]
                {
                    { 1, "Year 1" },
                    { 2, "Year 2" },
                    { 3, "Year 3" },
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "FirstName", "LastName", "SchoolId", "UserTypeId", "YearGroupId" },
                values: new object[,]
                {
                    { 1, null, "Ben", "Sztucki", 1, 1, null },
                    { 2, new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madeleine", "Williams", 1, 2, 1 },
                    { 3, null, "Frodo", "Baggins", 1, 1, null },
                    { 4, new DateTime(2015, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry", "Potter", 1, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "ClassAssignments",
                columns: new[] { "ClassId", "UserId", "SchoolId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 1, 2, 1 },
                    { 2, 2, 1 }
                });
        }
    }
}
