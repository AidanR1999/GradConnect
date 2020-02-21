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

    }
}