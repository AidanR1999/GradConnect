using System.ComponentModel.DataAnnotations;

namespace GradConnect.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }

        //Navigational properties
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}