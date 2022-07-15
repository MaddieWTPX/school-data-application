using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDataApplication.Migrations
{
    public partial class SeedDataMultipleUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "ClassAssignments",
                columns: new[] { "ClassId", "UserId", "SchoolId" },
                values: new object[,]
                {
                    { 2, 3, 1 },
                    { 3, 4, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "FirstName", "LastName", "UserTypeId", "YearGroupId" },
                values: new object[] { null, "Severus", "Snape", 1, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "UserTypeId" },
                values: new object[] { "Seymour", "Skinner", 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "FirstName", "LastName", "YearGroupId" },
                values: new object[] { null, "Haymitch", "Abernathy ", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "FirstName", "LastName", "SchoolId", "UserTypeId", "YearGroupId" },
                values: new object[,]
                {
                    { 5, null, "Edna", "Krabapple", 1, 1, null },
                    { 6, null, "Minerva", "McGonagall", 1, 1, null },
                    { 7, null, "Albus", "Dumbledore", 1, 1, null },
                    { 8, new DateTime(2011, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frodo", "Baggins", 1, 2, 6 },
                    { 9, new DateTime(2015, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry", "Potter", 1, 2, 2 },
                    { 10, new DateTime(2014, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", "Simpson", 1, 2, 3 },
                    { 11, new DateTime(2016, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katniss", "Everdeen", 1, 2, 4 },
                    { 12, new DateTime(2014, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milhouse", "Vanhouten", 1, 2, 5 },
                    { 13, new DateTime(2011, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samwise", "Gamgee", 1, 2, 6 },
                    { 14, new DateTime(2013, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bart", "Simpson", 1, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "ClassAssignments",
                columns: new[] { "ClassId", "UserId", "SchoolId" },
                values: new object[,]
                {
                    { 4, 5, 1 },
                    { 5, 6, 1 },
                    { 6, 7, 1 },
                    { 7, 8, 1 },
                    { 1, 9, 1 },
                    { 2, 9, 1 },
                    { 7, 9, 1 },
                    { 1, 10, 1 },
                    { 3, 10, 1 },
                    { 1, 11, 1 },
                    { 4, 11, 1 },
                    { 2, 12, 1 },
                    { 4, 12, 1 },
                    { 7, 12, 1 },
                    { 2, 13, 1 },
                    { 5, 13, 1 },
                    { 7, 13, 1 },
                    { 2, 14, 1 },
                    { 6, 14, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 7, 12 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 5, 13 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 7, 13 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "ClassAssignments",
                keyColumns: new[] { "ClassId", "UserId" },
                keyValues: new object[] { 6, 14 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14);

            migrationBuilder.InsertData(
                table: "ClassAssignments",
                columns: new[] { "ClassId", "UserId", "SchoolId" },
                values: new object[,]
                {
                    { 2, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "FirstName", "LastName", "UserTypeId", "YearGroupId" },
                values: new object[] { new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frodo", "Baggins", 2, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "UserTypeId" },
                values: new object[] { "Severus", "Snape", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "FirstName", "LastName", "YearGroupId" },
                values: new object[] { new DateTime(2015, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry", "Potter", 4 });
        }
    }
}
