using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GoodLuck.Models
{
    public class ReportViewModel
    {
        public int Customer { get; set; }
        public SelectList Customers { get; set; }
        public string ChallanNo { get; set; }
        public string Size { get; set; }
        public string Schedule { get; set; }
        public Nullable<DateTime> ChallanFromDate { get; set; }
        public Nullable<DateTime> ChallanToDate { get; set; }
        public List<Challan> Challans { get; set; }
    }
}