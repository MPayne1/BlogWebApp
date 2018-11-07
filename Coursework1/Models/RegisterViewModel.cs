using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Models
{
    public class RegisterViewModel
    {
        [Required, EmailAddress, MaxLength(256), Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), MaxLength(50), MinLength(6), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), MaxLength(50),MinLength(6), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }


    }
}
