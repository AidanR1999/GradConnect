using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Institution { get; set; }
        public string CourseName { get; set; }
        public string YearStart { get; set; }
        public string YearEnd { get; set; }
        
        public Education()
        {
            Modules = new List<Module>();
        }
        //Navigational props
        [InverseProperty("CV")]
        public int CvId { get; set; }
        public virtual CV Cv { get; set; }

        public IEnumerable<Module> Modules { get; set; }
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }        
    }
}