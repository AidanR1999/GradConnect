using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GradConnect.Models;

namespace GradConnect.ViewModels
{
    public class CreateJobsViewModel
    {
        [Display(Name = "Job Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Salary")]
        public double Salary { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Employment Type")]
        public string ContractType { get; set; }

        [Display(Name = "Contracted Hours")]
        public string ContractedHours { get; set; }

        [Display(Name = "Applicable Job Skills")]
        public List<Skill> Skills { get; set; }

        [Display(Name = "Selected Skills")]
        public List<JobSkill> SelectedSkills { get; set; }
    }
}
