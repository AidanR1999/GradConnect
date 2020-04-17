using System;
using System.Collections.Generic;

namespace GradConnect.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public string Location { get; set; }
        public string ContractType { get; set; }
        public string ContractedHours { get; set; }
        public DateTime? DatePosted { get; set; }

        //Naviagtional properties
        public IEnumerable<JobSkill> JobSkills { get; set; }
        public Job()
        {
            JobSkills = new List<JobSkill>();
        }
    }
}