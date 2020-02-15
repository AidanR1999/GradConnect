using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradConnect.Models
{
    public class User : IdentityUser
    {
        public User() : base() { }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string StudentEmial { get; set; }
        public bool StudentEmailConfirmed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string About { get; set; }
        public string InstitutionName { get; set; }
        public string CourseName { get; set; }



    }
}
