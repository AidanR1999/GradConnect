using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class BookmarkedPost
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        [Key, Column(Order = 1)]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}