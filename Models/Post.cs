using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DatePosted { get; set; }
        public int Thumbnail { get; set; }

        public Post()
        {
            Photos = new List<Photo>();
            BookmarkedPosts = new List<BookmarkedPost>();
            PostSkills = new List<PostSkill>();
        }
        //Naviagtional properties        
        public IEnumerable<Photo> Photos { get; set; }
        public IEnumerable<BookmarkedPost> BookmarkedPosts { get; set; }
        public IEnumerable<PostSkill> PostSkills { get; set; }

        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        

    }
}