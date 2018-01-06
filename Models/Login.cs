using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoodLuck.Models
{
    public class Login
    {
        [Required(ErrorMessage = "User Name is required", AllowEmptyStrings = false)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RemeberMe { get; set; }
    }
}