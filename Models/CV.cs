using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }
        public string CvName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }
        public DateTime DateOfBirth { get; set; }        
        public string  PersonalStatement { get; set; } 

        public CV()
        {
            Experiences = new List<Experience>();
            Educations = new List<Education>();
            References = new List<Reference>();
            Skills = new List<Skill>();
        }

        //Navigational properties
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }        
        public List<Experience> Experiences { get; set; }
        public List<Education> Educations { get; set; }
        public List<Reference> References { get; set; }
        public List<Skill> Skills { get; set; }
        
    }
}