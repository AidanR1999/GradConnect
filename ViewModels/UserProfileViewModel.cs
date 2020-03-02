using System.Collections.Generic;
using GradConnect.Models;

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
        public Photo ProfilePicture { get; set; }
        public IEnumerable<Portfolio> UserPortfolios { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
        public List<Skill> ListOfSkills { get; set; }

    }
}