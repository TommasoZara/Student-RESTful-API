using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Inheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nationality = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Course = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    College = table.Column<string>(type: "TEXT", nullable: true),
                    HasGraduated = table.Column<bool>(type: "INTEGER", nullable: false),
                    StudentCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    Topic = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    DateOfTest = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exam_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Exam",
                columns: new[] { "Id", "DateOfTest", "DurationMinutes", "InstructorId", "StudentId", "Topic" },
                values: new object[] { 1, new DateTime(2021, 9, 10, 8, 20, 0, 0, DateTimeKind.Unspecified), 60, null, null, "SICUREZZA DELLE ARCHITETTURE ORIENTATE AI SERVIZI" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Nationality", "Password", "Username" },
                values: new object[] { 2, new DateTime(1969, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "InstructorName", "InstructorLastName", "ITA", "A8CE55AB5C4CAFCF959B534FF5BB8DCF", "Prof1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Nationality", "Password", "Username" },
                values: new object[] { 1, new DateTime(1999, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tommaso", "Zarantonello", "ITA", "F8C2475361C649AF0F3BF7C2E2AA5160", "Tom" });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Course", "HireDate" },
                values: new object[] { 2, "SICUREZZA DELLE ARCHITETTURE ORIENTATE AI SERVIZI", new DateTime(1999, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "College", "HasGraduated", "StudentCode" },
                values: new object[] { 1, "Unimi", false, 12345 });

            migrationBuilder.CreateIndex(
                name: "IX_Exam_InstructorId",
                table: "Exam",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_StudentId",
                table: "Exam",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
