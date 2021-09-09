using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Instructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Nationality", "Password", "Username" },
                values: new object[] { 4, new DateTime(1969, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario", "Rossi", "ITA", "A8CE55AB5C4CAFCF959B534FF5BB8DCF", "MarioR" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Nationality", "Password", "Username" },
                values: new object[] { 5, new DateTime(1978, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paolo", "Bianchi", "ITA", "A8CE55AB5C4CAFCF959B534FF5BB8DCF", "Paolo" });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Course", "HireDate" },
                values: new object[] { 4, "SICUREZZA DELLE ARCHITETTURE ORIENTATE AI SERVIZI", new DateTime(1999, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Course", "HireDate" },
                values: new object[] { 5, "SISTEMI BIOMETRIFCI", new DateTime(2000, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstructorId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstructorId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstructorId",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Nationality", "Password", "Username" },
                values: new object[] { 7, new DateTime(1969, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario", "Rossi", "ITA", "A8CE55AB5C4CAFCF959B534FF5BB8DCF", "MarioR" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Nationality", "Password", "Username" },
                values: new object[] { 8, new DateTime(1978, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paolo", "Bianchi", "ITA", "A8CE55AB5C4CAFCF959B534FF5BB8DCF", "Paolo" });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Course", "HireDate" },
                values: new object[] { 7, "SICUREZZA DELLE ARCHITETTURE ORIENTATE AI SERVIZI", new DateTime(1999, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Course", "HireDate" },
                values: new object[] { 8, "SISTEMI BIOMETRIFCI", new DateTime(2000, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstructorId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstructorId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstructorId",
                value: 7);
        }
    }
}
