using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoodLuck.Models
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Current Password is required", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New Password is required", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Display(Name = "New Password")]
        [StringLength(8, ErrorMessage = "Must be between 4 and 8 characters", MinimumLength = 4)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm New Password is required", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [StringLength(8, ErrorMessage = "Must be between 4 and 8 characters", MinimumLength = 4)]
        [Compare("NewPassword", ErrorMessage = "'New Password' and 'Confirm New Password' does not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}