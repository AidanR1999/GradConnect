using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string EmployerName { get; set; }

        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}