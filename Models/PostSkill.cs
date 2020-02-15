namespace GradConnect.Models
{
    public class PostSkill
    {
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}