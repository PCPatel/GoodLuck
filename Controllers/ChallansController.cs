using GoodLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodLuck.Controllers
{
    [Authorize]
    public class ChallansController : Controller
    {
        private GoodLuckEntities _context;
        public ChallansController()
        {
            _context = new GoodLuckEntities();
        }

        // GET: Challans
        public ActionResult Index(int id = 0)
        {
            ChallanViewModel cvm = new ChallanViewModel
            {
                Customer = id,
                Customers = new SelectList(
                _context.Customers
                .Select(x => new { x.Id, x.Name })
                //.OrderBy(x => x.Name)
                .ToList(), "Id", "Name", id),
                Challans = _context.Challans
                .Where(x => x.CustomerId == id)
                .OrderByDescending(x => x.ChallanDate).ToList()
            };
            return View(cvm);
        }

        public ActionResult Create()
        {
            SelectList CustList = new SelectList(
                 _context.Customers
                 .Select(x => new { x.Id, x.Name })
                 .OrderBy(x => x.Name)
                 .ToList(), "Id", "Name", 0);
            List<Challan> Challans = new List<Challan>();
            Challans.Add(new Challan());

            ChallanViewModel cvm = new ChallanViewModel
            {
                Customer = 0,
                Customers = CustList,
                Challans = Challans
            };

            return View(cvm);
        }
        [HttpPost]
        public ActionResult Create(ChallanViewModel challanViewModel)
        {
            if (ModelState.IsValid)
            {
                foreach (Challan ch in challanViewModel.Challans)
                {
                    ch.CustomerId = challanViewModel.Customer;
                }
                _context.Challans.AddRange(challanViewModel.Challans);
                _context.SaveChanges();

                ChallanViewModel cvm = new ChallanViewModel
                {
                    Customer = challanViewModel.Customer,
                    Customers = new SelectList(
                _context.Customers
                .Select(x => new { x.Id, x.Name })
                //.OrderBy(x => x.Name)
                .ToList(), "Id", "Name", challanViewModel.Customer),
                    Challans = _context.Challans
                .Where(x => x.CustomerId == challanViewModel.Customer)
                .OrderBy(x => x.ChallanDate).ToList()
                };
                return View("Index", cvm);

            }
            else
            {
                challanViewModel.Customers = new SelectList(
              _context.Customers
              .Select(x => new { x.Id, x.Name })
              .OrderBy(x => x.Name)
              .ToList(), "Id", "Name", challanViewModel.Customer);

                return View(challanViewModel);
            }

        }
        [HttpPost]
        public ActionResult AddMore(ChallanViewModel challanViewModel)
        {
            ModelState.Clear();
            challanViewModel.Customers = new SelectList(
                 _context.Customers
                 .Select(x => new { x.Id, x.Name })
                 .OrderBy(x => x.Name)
                 .ToList(), "Id", "Name", challanViewModel.Customer);
            challanViewModel.Challans.Add(new Challan());
            return View("Create", challanViewModel);
        }
        [HttpPost]
        public ActionResult Remove(ChallanViewModel challanViewModel, int id)
        {
            ModelState.Clear();
            challanViewModel.Customers = new SelectList(
                 _context.Customers
                 .Select(x => new { x.Id, x.Name })
                 .OrderBy(x => x.Name)
                 .ToList(), "Id", "Name", challanViewModel.Customer);
            //challanViewModel.Challans.Remove(challanViewModel.Challans.Where(x => x.Id == id).FirstOrDefault());
            challanViewModel.Challans.RemoveAt(id);
            return View("Create", challanViewModel);
        }

        public ActionResult Edit(int id)
        {
            ViewData["CustomerList"] = new SelectList(
                  _context.Customers
                  .Select(x => new { x.Id, x.Name })
                  .OrderBy(x => x.Name)
                  .ToList(), "Id", "Name", id);
            Challan ch = _context.Challans.Where(x => x.Id == id).FirstOrDefault();
            return View(ch);
        }

        [HttpPost]
        public ActionResult Edit(Challan ch)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(ch).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index", new { id = ch.CustomerId });
            }
            else
            {
                ViewData["CustomerList"] = new SelectList(
                 _context.Customers
                 .Select(x => new { x.Id, x.Name })
                 .OrderBy(x => x.Name)
                 .ToList(), "Id", "Name", ch.CustomerId);
            }
            return View(ch);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Challan ch = _context.Challans.Find(id);
            _context.Challans.Remove(ch);
            _context.SaveChanges();
            TempData["message"] = "Challan deleted successfully";
            return RedirectToAction("Index", new { id = ch.CustomerId });
        }
    }
}