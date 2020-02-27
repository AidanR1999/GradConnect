using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GradConnect.Models;

namespace GradConnect.ViewModels
{
    public class UpdateCvViewModel
    {
        [Display(Name = "CV Title")]
        public string CvName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Street and house number")]
        public string Street { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Personal statement")]        
        public string  PersonalStatement { get; set; }

        [Display(Name = "Your experience")] 
        public List<Experience> Experiences { get; set; }

        [Display(Name = "Your finished courses")]
        public List<Education> Educations { get; set; }        
        public List<Reference> References { get; set; }
        public List<Skill> Skills { get; set; }
        
    }
}