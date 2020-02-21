namespace GradConnect.Models
{
    public class Sponsored : Post
    {
        [InverseProperty("Employer")]
        public int EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
    }
}