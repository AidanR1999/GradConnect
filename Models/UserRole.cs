namespace GradConnect.Models
{
    public class UserRole
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}