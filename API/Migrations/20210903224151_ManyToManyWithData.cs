using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ManyToManyWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exam",
                columns: new[] { "Id", "DateOfTest", "DurationMinutes", "InstructorId", "Topic" },
                values: new object[] { 2, new DateTime(2020, 2, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), 120, null, "SICUREZZA DEI SISTEMI E DELLE RETI" });

            migrationBuilder.InsertData(
                table: "Exam",
                columns: new[] { "Id", "DateOfTest", "DurationMinutes", "InstructorId", "Topic" },
                values: new object[] { 3, new DateTime(2020, 12, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), 90, null, "RETI DI CALCOLATORI	" });

            migrationBuilder.InsertData(
                table: "StudentExam",
                columns: new[] { "ExamId", "StudentId", "Vote" },
                values: new object[] { 1, 1, 30 });

            migrationBuilder.InsertData(
                table: "StudentExam",
                columns: new[] { "ExamId", "StudentId", "Vote" },
                values: new object[] { 2, 1, 28 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentExam",
                keyColumns: new[] { "ExamId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentExam",
                keyColumns: new[] { "ExamId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Exam",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
