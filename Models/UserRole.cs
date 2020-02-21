namespace GradConnect.Models
{
    public class UserRole
    {
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [InverseProperty("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}