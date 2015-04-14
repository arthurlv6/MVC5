using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Web.Models
{
    public class VMCustomerEmail
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^(\d{7,11})$", ErrorMessage = "Please enter proper phone number.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "This is not available phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "This is not available email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [Display(Name = "Message")]
        public string Detail { get; set; }
        public int SettingId { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
    }
}
