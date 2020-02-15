namespace GradConnect.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Description { get; set; }
        //Navigational properties
        public int PhotoId { get; set; }
        public virtual Photo Photo  { get; set; }

        public string UserId { get; set; }   
        public virtual User User { get; set; }
        
    }
}