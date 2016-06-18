using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IR_BackOffice.Models
{
    public class EnquiryModel
    {
        [Required]
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }

        [DisplayName("Telephone Number")]
        public string TelephoneNumber { get; set; }

        [Required]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [DisplayName("Confirm Email Address")]
        [DataType(DataType.EmailAddress)]
        [Compare("EmailAddress", ErrorMessage = "The Email Addresses Do Not Match")]
        public string EmailConfirm { get; set; }

        [Required]
        [DisplayName("Enquiry")]
        [DataType(DataType.MultilineText)]
        public string Enquiry { get; set; }

        [DisplayName("Send a copy to yourself")]
        [DataType(DataType.Text)]
        public bool SendToSelf { get; set; }
    }
}