using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API
{
    public class User
    {
        public User(string username, string password, string firstName, string lastName, DateTime dateOfBirth, string nationality)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Nationality = nationality;
            
            Username = username;
            Password = password;
        }

        public int Id { get; set; } = -1;

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
        public string Nationality { get; set; }


        /// <summary>
        /// CREDENTIAL STUFF            https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/inheritance?view=aspnetcore-5.0
        /// </summary>
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}