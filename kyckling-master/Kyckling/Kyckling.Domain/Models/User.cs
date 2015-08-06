using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;


namespace Kyckling.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage = "Please provide valid email")]// Engelska lr svenska ??:S
        [Display(Name = "Email Address: ")]
        [StringLength(150)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Password")]// Vi använder resource filer sen..
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Password must be 8 char long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please provide full name", AllowEmptyStrings = false)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please provide full last name", AllowEmptyStrings = false)]
        public string Lastname { get; set; }
    }
}
