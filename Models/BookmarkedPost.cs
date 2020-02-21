using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class BookmarkedPost
    {
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [InverseProperty("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}