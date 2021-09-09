using API.Entities;
using API.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>().ToTable("Exam");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<StudentExam>().HasKey(t => new { t.StudentId, t.ExamId });


            modelBuilder.Entity<StudentExam>()
                            .HasOne(pt => pt.Student)
                            .WithMany(p => p.Exams)
                            .HasForeignKey(pt => pt.StudentId);

            modelBuilder.Entity<StudentExam>()
                            .HasOne(pt => pt.Exam)
                            .WithMany(t => t.Students)
                            .HasForeignKey(pt => pt.ExamId);

            modelBuilder.Entity<Exam>()
                            .HasOne(p => p.Instructor)
                            .WithMany(b => b.Exams);


            modelBuilder.Entity<Exam>().HasData(new Exam[] {
                new Exam(){ Id = 1, DateOfTest = new DateTime(2021, 9, 10, 8, 20, 0), DurationMinutes=60, Topic="SICUREZZA DELLE ARCHITETTURE ORIENTATE AI SERVIZI", InstructorId=5 },
                new Exam(){ Id = 2, DateOfTest = new DateTime(2020, 2, 12, 7, 0, 0), DurationMinutes=120, Topic="SICUREZZA DEI SISTEMI E DELLE RETI", InstructorId=5},
                new Exam(){ Id = 3, DateOfTest = new DateTime(2020, 12, 21, 18, 0, 0), DurationMinutes=90, Topic="RETI DI CALCOLATORI", InstructorId=4 }
            });

            modelBuilder.Entity<Student>().HasData(new Student[] {
                new Student(){Id = 1, Username= "Tom", Password= "Zara".ToMD5(), FirstName = "Tommaso", LastName = "Zarantonello", DateOfBirth =  new DateTime(1999, 2, 21), Nationality =  "ITA", College =  "Unimi",  StudentCode = 12345 }
            });

            modelBuilder.Entity<Instructor>().HasData(new Instructor[] {
                new Instructor() {Id = 4, Username = "MarioR", Password = "Pwd".ToMD5(), FirstName = "Mario", LastName = "Rossi", DateOfBirth = new DateTime(1969, 7, 22), Nationality = "ITA", HireDate = new DateTime(1999, 6, 10), Course = "SICUREZZA DELLE ARCHITETTURE ORIENTATE AI SERVIZI"},
                new Instructor() {Id = 5, Username = "Paolo", Password = "Pwd".ToMD5(), FirstName = "Paolo", LastName = "Bianchi", DateOfBirth = new DateTime(1978, 2, 10), Nationality = "ITA", HireDate = new DateTime(2000, 2, 21), Course = "SISTEMI BIOMETRIFCI"}
            });

            modelBuilder.Entity<StudentExam>().HasData(new StudentExam[] { 
                new StudentExam(){ ExamId = 1, StudentId = 1, Vote = 30 },
                new StudentExam(){ ExamId = 2, StudentId = 1, Vote = 28 },
            });

        }

    }
}
