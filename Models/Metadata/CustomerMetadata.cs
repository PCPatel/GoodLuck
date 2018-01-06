using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoodLuck.Models
{
    public class CustomerMetadata
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Address1 { get; set; }

        [Required]
        [StringLength(250)]
        public string Address2 { get; set; }
        public int Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        [Display(Name = "GST No.")]
        public string GSTNO { get; set; }

        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [Display(Name = "Added By")]
        public string AddedBy { get; set; }

        [Display(Name = "Added On")]
        public System.DateTime AddedOn { get; set; }
    }
}