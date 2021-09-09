using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Exam
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "The exam duration in minutes")]
        public int DurationMinutes { get; set; }

        [Required]
        [StringLength(250)]
        public string Topic { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Test Date")]
        public DateTime DateOfTest { get; set; }


        //--- relation stuff      
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<StudentExam> Students { get; set; }


        public bool IsValid() => !(DurationMinutes < 30 || DurationMinutes > 240 || string.IsNullOrWhiteSpace(Topic) || DateOfTest < DateTime.Now.AddDays(30) || InstructorId < 0);

    }
}
