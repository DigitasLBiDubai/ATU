using System.ComponentModel.DataAnnotations;

namespace ATU.Web.Domain.Model.Request
{
    public class RequestFields
    { // { "Text" : "", "FirstName" : "", "LastName" : "", "PhoneNumber" : "", "Url" : "", "Email" : "", "Status" : "0", "Type" : "1" } 
        [Required]
        [Display(Name = "Introduce yourself")]
        [StringLength(200, ErrorMessage = "The text must be less than {0} characters long", MinimumLength = 6)]
        public string Text { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [Phone(ErrorMessage = "Please provide a valid phone number")]
        [StringLength(40, ErrorMessage = "The phone number must be less than {0} characters long", MinimumLength = 6)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Website Url")]
        [StringLength(80, ErrorMessage = "The website url must be less than {0} characters long", MinimumLength = 6)]
        public string Url { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int Status { get; set; }

        public int RequestType { get; set; }

    }
}