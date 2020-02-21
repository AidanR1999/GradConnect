using System;

namespace GradConnect.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public string ContentLink { get; set; }
        public DateTime? DateSubmitted { get; set; }
        
        //Navigational properties
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [InverseProperty("Challenge")]
        public int ChallengeId { get; set; }
        public virtual Challenge Challenge { get; set; }
    }
}