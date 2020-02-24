using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class JobSkill
    {
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}