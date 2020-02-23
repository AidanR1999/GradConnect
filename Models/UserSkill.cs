using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class UserSkill
    {
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [InverseProperty("Skill")]
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}