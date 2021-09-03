using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class User
    {
        //public User(string username, string password, string firstName, string lastName, DateTime dateOfBirth, string nationality)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    DateOfBirth = dateOfBirth;
        //    Nationality = nationality;
            
        //    Username = username;
        //    Password = password;
        //}

        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nation")]
        public string Nationality { get; set; }


        [Display(Name = "Full Name")]
        public string FullName => LastName + ", " + FirstName;


        /// <summary>
        /// CREDENTIAL STUFF
        /// </summary>
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}