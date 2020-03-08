using System.Collections.Generic;
using GradConnect.Models;
using Microsoft.AspNetCore.Http;

namespace GradConnect.ViewModels
{
    public class UserProfileViewModel
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Institution { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public string About { get; set; }
        public bool VerifiedStudent { get; set; }
        public IFormFile ProfilePicture { get; set; }        
        public string ProfilePhoto { get; set; }
        public IEnumerable<Portfolio> UserPortfolios { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
        public List<Skill> ListOfSkills { get; set; }

    }
}