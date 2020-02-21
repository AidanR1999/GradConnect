using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class JobSkill
    {
        [InverseProperty("Job")]
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        [InverseProperty("Skill")]
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}