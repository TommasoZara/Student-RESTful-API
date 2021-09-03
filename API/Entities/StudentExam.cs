using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class StudentExam
    {
        public int Vote { get; set; }
        public bool IsPassed => Vote >= 18;


        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
