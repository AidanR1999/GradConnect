using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Display(Name = "What year you started working?")]
        public string YearStart { get; set; }
        [Display(Name = "What year you finished?")]
        public string YearEnd { get; set; }
        public string Responsibilities { get; set; }

        //Navigational props
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [InverseProperty("CV")]
        public int? CvId { get; set; }
        public virtual CV Cv { get; set; }
    }
}