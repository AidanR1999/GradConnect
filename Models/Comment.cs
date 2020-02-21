using System;
using System.ComponentModel.DataAnnotations;

namespace GradConnect.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? DatePosted { get; set; }

        //Navigational properties
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [InverseProperty("Article")]
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}