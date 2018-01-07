using GoodLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodLuck.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private GoodLuckEntities _context;
        public ReportController()
        {
            _context = new GoodLuckEntities();
        }

        // GET: Report
        [HttpGet]
        public ActionResult Index()
        {
            ReportViewModel rvm = new ReportViewModel
            {
                Customer = 0,
                Customers = new SelectList(
                _context.Customers
                .Select(x => new { x.Id, x.Name })
                //.OrderBy(x => x.Name)
                .ToList(), "Id", "Name", 0),
                Size = "",
                Schedule = "",
                ChallanFromDate = null,
                ChallanToDate = null,
                ChallanNo = "",
                Challans = new List<Challan>()
                //_context.Challans
                //.Where(x => x.CustomerId == (Customer > 0 ? Customer : x.CustomerId))
                //.Where(x => x.Size.StartsWith(Size))
                //.Where(x => x.Schedule.StartsWith(Schedule))
                //.Where(x => x.ChallanNo.StartsWith(ChallanNo))
                //.Where(x => x.ChallanDate >= (ChallanFromDate == null ? x.ChallanDate : ChallanFromDate) &&
                //            x.ChallanDate <= (ChallanToDate == null ? x.ChallanDate : ChallanToDate))
                //.OrderByDescending(x => x.ChallanDate).ToList()
            };
            return View(rvm);
        }
        [HttpPost]
        public ActionResult Index(int Customer = 0, string Size = "", string Schedule = "",
            string ChallanNo = "", Nullable<DateTime> ChallanFromDate = null, Nullable<DateTime> ChallanToDate = null)
        {
            ReportViewModel rvm = new ReportViewModel
            {
                Customer = Customer,
                Customers = new SelectList(
                _context.Customers
                .Select(x => new { x.Id, x.Name })
                //.OrderBy(x => x.Name)
                .ToList(), "Id", "Name", Customer),
                Size = Size,
                Schedule = Schedule,
                ChallanFromDate = ChallanFromDate,
                ChallanToDate = ChallanToDate,
                ChallanNo = ChallanNo,
                Challans = _context.Challans
                            .Where(x => x.CustomerId == (Customer > 0 ? Customer : x.CustomerId))
                            .Where(x => x.Size.StartsWith(Size))
                            .Where(x => x.Schedule.StartsWith(Schedule))
                            .Where(x => x.ChallanNo.StartsWith(ChallanNo))
                            .Where(x => x.ChallanDate >= (ChallanFromDate == null ? x.ChallanDate : ChallanFromDate) &&
                                        x.ChallanDate <= (ChallanToDate == null ? x.ChallanDate : ChallanToDate))
                            .OrderByDescending(x => x.ChallanDate).ToList()
            };
            return View(rvm);
        }
    }
}