using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ODA.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string FullName { get; set; }
        [StringLength(100)]
        [MinLength(10), MaxLength(16)]
        public string PrimaryMobile { get; set; } = "07";
        [Required]
        [MinLength(4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(170)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}
