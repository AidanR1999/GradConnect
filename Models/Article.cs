using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradConnect.Models
{
    public class Article : Post
    {

        public Article()
        {
            Comments = new List<Comment>();
        }
        public string Link { get; set; }
        //Navigational props
        public IEnumerable<Comment> Comments { get; set; }
    }
}