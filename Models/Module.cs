using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Grade { get; set; }
        
        //Navigational props
        [InverseProperty("Education")]
        public int EducationId { get; set; }
        public virtual Education Education { get; set; }

    }
}