using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Student_StudentId",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_StudentId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Exam");

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_ExamId",
                table: "StudentExam",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentExam");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Exam",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_StudentId",
                table: "Exam",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Student_StudentId",
                table: "Exam",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
