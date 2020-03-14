using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace GradConnect.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile PictureFile { get; set; }
        
        //Navigational properties
        [InverseProperty("Photo")]
        public int? PhotoId { get; set; }
        public virtual Photo Photo  { get; set; }
        
        [InverseProperty("User")]
        public string UserId { get; set; }   
        public virtual User User { get; set; }
        
    }
}