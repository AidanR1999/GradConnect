using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradConnect.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Link { get; set; }
        public DateTime? DateUploaded { get; set; }

        //Naviagtional properties
        [InverseProperty("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}