using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradConnect.Models
{
    public class User : IdentityUser
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string StudentEmial { get; set; }
        public bool StudentEmailConfirmed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string About { get; set; }
        public string InstitutionName { get; set; }
        public string CourseName { get; set; }

        public User()
        {
            UserRoles = new List<UserRole>();
            Experiences = new List<Experience>();
            CVs = new List<CV>();
            Portfolios = new List<Portfolio>();
            UserSkills = new List<UserSkill>();
            BookmarkedPosts = new List<BookmarkedPost>();
            Submissions = new List<Submission>();
            Comments = new List<Comment>();
            Posts = new List<Post>();
            Educations = new List<Education>();
        }
        //Naviagtional properties
        public IEnumerable<UserRole> UserRoles { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
        public IEnumerable<CV> CVs { get; set; }
        public IEnumerable<Portfolio> Portfolios { get; set; }
        public IEnumerable<UserSkill> UserSkills { get; set; }
        public IEnumerable<BookmarkedPost> BookmarkedPosts { get; set; }
        public IEnumerable<Submission> Submissions { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Education> Educations { get; set; }

        [InverseProperty("Photo")]
        public int? PhotoId { get; set; }
        public virtual Photo Photo { get; set; }
    }
}
