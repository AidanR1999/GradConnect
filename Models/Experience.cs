using System.ComponentModel.DataAnnotations;

namespace GradConnect.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string EmployerName { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}