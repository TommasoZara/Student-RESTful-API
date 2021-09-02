using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Student : User
    {
        public Student(string username, string password, string firstName, string lastName, DateTime dateOfBirth, string nationality, string collage, string studentCode) 
                : base(username, password, firstName, lastName, dateOfBirth, nationality)
        {
            College = collage;
            StudentCode = studentCode;
        }

        public string College { get; set; }
        public bool HasGraduated { get; set; }
        public string StudentCode { get; set; }     //--- Matricola ?!
    }
}
