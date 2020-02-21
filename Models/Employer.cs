using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradConnect.Models
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigational props
        public IEnumerable<Job> Jobs { get; set; }
        public IEnumerable<Sponsored> SponsoredPosts { get; set; }
        public IEnumerable<Challenge> Challenges { get; set; }
        public Employer()
        {
            Jobs = new List<Job>();
            SponsoredPosts = new List<Sponsored>();
            Challenges = new List<Challenge>();
        }
    }
}