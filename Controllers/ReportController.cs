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
        public ActionResult Index(int Customer = 0, string Size = "", string Schedule = "")
        {
            ReportViewModel rvm = new ReportViewModel
            {
                Customer = Customer,
                Customers = new SelectList(
                _context.Customers
                .Select(x => new { x.Id, x.Name })
                //.OrderBy(x => x.Name)
                .ToList(), "Id", "Name", Customer),
                Challans = _context.Challans
                .Where(x => x.CustomerId == Customer)
                .OrderByDescending(x => x.ChallanDate).ToList()
            };
            return View(rvm);
        }
    }
}