using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Exam
    {

        //public Exam(int timeMinutes, string topic)
        //{
        //    DurationMinutes = timeMinutes;
        //    Topic = topic;
        //}

        public int Id { get; set; } = -1;

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


        public ICollection<StudentExam> Students { get; set; }
    }
}
