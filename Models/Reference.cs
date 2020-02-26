using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class Reference
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber  { get; set; }
        public string Email { get; set; }

        //Navigational property
        [InverseProperty("CV")]
        public int CvId { get; set; }
        public virtual CV Cv { get; set; }
    }
}