using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoodLuck.Models
{
    public class ChallanMetadata
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [StringLength(20)]
        [Display(Name = "Challan No")]
        public string ChallanNo { get; set; }

        [Required]
        [Display(Name ="Challan Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ChallanDate { get; set; }

        [Required]
        [StringLength(10)]
        public string Size { get; set; }

        [Required]
        [StringLength(10)]
        public string Schedule { get; set; }

        [Required]
        [Display(Name = "Length (Inch)")]
        public Nullable<int> Length { get; set; }

        [Display(Name = "90D Nos")]
        public Nullable<int> C90D_Nos { get; set; }

        [Display(Name = "90D Len")]
        public Nullable<int> C90D_Length { get; set; }

        [Display(Name = "1D Nos")]
        public Nullable<int> C1D_Nos { get; set; }

        [Display(Name = "1D Len")]
        public Nullable<int> C1D_Length { get; set; }

        [Display(Name = "45D Nos")]
        public Nullable<int> C45D_Nos { get; set; }

        [Display(Name = "45D Len")]
        public Nullable<int> C45D_Length { get; set; }

        [Display(Name = "Long Nos")]
        public Nullable<int> Long_Nos { get; set; }

        [Display(Name = "Long Len")]
        public Nullable<int> Long_Length { get; set; }

        [Display(Name = "Reducer Nos")]
        public Nullable<int> Reducer_Nos { get; set; }

        [Display(Name = "Reducer Len")]
        public Nullable<int> Reducer_Length { get; set; }

        [Display(Name = "Balance Len")]
        public Nullable<int> Balance_Length { get; set; }

        [Display(Name = "Scrap Len")]
        public Nullable<int> Scrap_Length { get; set; }

        [Display(Name = "Scrap Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Scrap_Date { get; set; }
    }
}