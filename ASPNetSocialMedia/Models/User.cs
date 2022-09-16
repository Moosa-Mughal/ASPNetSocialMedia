using System.ComponentModel.DataAnnotations;

namespace ASPNetSocialMedia.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{this.FirstName} {this.LastName}";
        [Required, EmailAddress]
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public string? Biography { get; set; }
        public string? ProfileImage { get; set; } = "NoImageFound.png";
        public string Password { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AdminID { get; set; }
    }
}
