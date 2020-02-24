using System.Collections.Generic;

namespace GradConnect.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //Naviagtional properties
        public IEnumerable<JobSkill> JobSkills { get; set; }
        public Job()
        {
            JobSkills = new List<JobSkill>();
        }
    }
}