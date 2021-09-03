using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Instructor : User
    {

        //public Instructor(string username, string password, string firstName, string lastName, DateTime dateOfBirth, string nationality, DateTime hiredate, string course)
        //        : base(username, password, firstName, lastName, dateOfBirth, nationality)
        //{
        //    HireDate = hiredate;
        //    Course = course;
        //}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public string Course { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
