using System;

namespace GradConnect.ViewModels
{
    public class CreateCvViewModel
    {
        public string CvName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }
        public DateTime DateOfBirth { get; set; }        
        public string  PersonalStatement { get; set; } 
    }
}