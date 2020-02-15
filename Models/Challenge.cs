using System.Collections.Generic;

namespace GradConnect.Models
{
    public class Challenge : Post
    {
        public string Task { get; set; }
        //Navigastional props
        public IEnumerable<Submission> Submissions { get; set; }
        public int EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
        public Challenge()
        {
            Submissions = new List<Submission>();
        }
    }
}