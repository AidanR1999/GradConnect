using GradConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradConnect.ViewModels
{
    public class PostCardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DatePosted { get; set; }
        public string Description { get; set; }
        public double? Salary { get; set; }
        public string Location { get; set; }
        public string ContractType { get; set; }
        public int? Icon { get; set; }
        public IEnumerable<Skill> Skills { get; set; }

        public PostCardViewModel()
        {
            Skills = new List<Skill>();
        }
    }
}
