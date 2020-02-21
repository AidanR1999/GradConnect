using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class PostSkill
    {
        [InverseProperty("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        [InverseProperty("Skill")]
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
