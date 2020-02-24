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
        public string Address { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Navigational properties
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}