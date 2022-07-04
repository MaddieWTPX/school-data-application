using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDataApplication.Migrations
{
    public partial class FluentAPIClassAssignmentKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAssignments_SchoolClasses_SchoolClassClassId",
                table: "ClassAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ClassAssignments_SchoolClassClassId",
                table: "ClassAssignments");

            migrationBuilder.DropColumn(
                name: "SchoolClassClassId",
                table: "ClassAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "YearGroup",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAssignments_ClassId",
                table: "ClassAssignments",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAssignments_SchoolClasses_ClassId",
                table: "ClassAssignments",
                column: "ClassId",
                principalTable: "SchoolClasses",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAssignments_SchoolClasses_ClassId",
                table: "ClassAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ClassAssignments_ClassId",
                table: "ClassAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "YearGroup",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolClassClassId",
                table: "ClassAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassAssignments_SchoolClassClassId",
                table: "ClassAssignments",
                column: "SchoolClassClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAssignments_SchoolClasses_SchoolClassClassId",
                table: "ClassAssignments",
                column: "SchoolClassClassId",
                principalTable: "SchoolClasses",
                principalColumn: "ClassId");
        }
    }
}
