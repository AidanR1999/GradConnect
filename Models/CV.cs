using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Experience { get; set; }
        public string  PersonalStatement { get; set; }
        public string Education { get; set; }
        public string References { get; set; }
    

        //Navigational properties
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}