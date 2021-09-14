using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : Migration
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
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentExam",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Vote = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExam", x => new { x.StudentId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_StudentExam_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentExam_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Nationality", "Password", "Username" },
                values: new object[] { 4, new DateTime(1969, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario", "Rossi", "ITA", "A8CE55AB5C4CAFCF959B534FF5BB8DCF", "MarioR" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Nationality", "Password", "Username" },
                values: new object[] { 5, new DateTime(1978, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paolo", "Bianchi", "ITA", "A8CE55AB5C4CAFCF959B534FF5BB8DCF", "Paolo" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Nationality", "Password", "Username" },
                values: new object[] { 1, new DateTime(1999, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tommaso", "Zarantonello", "ITA", "F8C2475361C649AF0F3BF7C2E2AA5160", "Tom" });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Course", "HireDate" },
                values: new object[] { 4, "SICUREZZA DELLE ARCHITETTURE ORIENTATE AI SERVIZI", new DateTime(1999, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Course", "HireDate" },
                values: new object[] { 5, "SISTEMI BIOMETRIFCI", new DateTime(2000, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "College", "HasGraduated", "StudentCode" },
                values: new object[] { 1, "Unimi", false, 12345 });

            migrationBuilder.InsertData(
                table: "Exam",
                columns: new[] { "Id", "DateOfTest", "DurationMinutes", "InstructorId", "Topic" },
                values: new object[] { 3, new DateTime(2020, 12, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), 90, 4, "RETI DI CALCOLATORI" });

            migrationBuilder.InsertData(
                table: "Exam",
                columns: new[] { "Id", "DateOfTest", "DurationMinutes", "InstructorId", "Topic" },
                values: new object[] { 1, new DateTime(2021, 9, 10, 8, 20, 0, 0, DateTimeKind.Unspecified), 60, 5, "SICUREZZA DELLE ARCHITETTURE ORIENTATE AI SERVIZI" });

            migrationBuilder.InsertData(
                table: "Exam",
                columns: new[] { "Id", "DateOfTest", "DurationMinutes", "InstructorId", "Topic" },
                values: new object[] { 2, new DateTime(2020, 2, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), 120, 5, "SICUREZZA DEI SISTEMI E DELLE RETI" });

            migrationBuilder.InsertData(
                table: "StudentExam",
                columns: new[] { "ExamId", "StudentId", "Vote" },
                values: new object[] { 1, 1, 30 });

            migrationBuilder.InsertData(
                table: "StudentExam",
                columns: new[] { "ExamId", "StudentId", "Vote" },
                values: new object[] { 2, 1, 28 });

            migrationBuilder.CreateIndex(
                name: "IX_Exam_InstructorId",
                table: "Exam",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_ExamId",
                table: "StudentExam",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentExam");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
