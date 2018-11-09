using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Models
{
    public class RegisterVM
    {
        [Required, EmailAddress, MaxLength(256), Display(Name = "Email Addresss")]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(256), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MinLength(8), MaxLength(256), DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="The passwords don't match")]
        public string ConfirmPassword { get; set; }

    }
}
