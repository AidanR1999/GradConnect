using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Skill()
        {
            UserSkills = new List<UserSkill>();
            PostSkills = new List<PostSkill>();
            JobSkills = new List<JobSkill>();
        }
        //Navigational properties

        public IEnumerable<UserSkill> UserSkills { get; set; }
        public IEnumerable<PostSkill> PostSkills { get; set; }
        public IEnumerable<JobSkill> JobSkills { get; set; }


        [InverseProperty("CV")]
        public int? CvId { get; set; }
        public virtual CV Cv { get; set; }
    }
}