using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodLuck.Models
{
    public class ChallanViewModel
    {
        public int Customer { get; set; }
        public SelectList Customers { get; set; }
        public List<Challan> Challans { get; set; }
    }
}