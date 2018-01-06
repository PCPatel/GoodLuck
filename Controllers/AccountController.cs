using GoodLuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GoodLuck.Controllers
{
    public class AccountController : Controller
    {
        private GoodLuckEntities _context;
        public AccountController()
        {
            _context = new GoodLuckEntities();
        }

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(
                    x => x.UserName.Equals(login.UserName) &&
                    x.Password.Equals(login.Password))
                    .FirstOrDefault();
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, login.RemeberMe);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.Remove("Password");
                    ModelState.AddModelError("", "User Name or Password incorrect");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: ChangePassword
        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        // GET: ChangePassword
        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword cp)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(
                    x => x.UserName.Equals(User.Identity.Name) &&
                    x.Password.Equals(cp.CurrentPassword))
                    .FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("CurrentPassword", "Current password does not match");
                }
                else if (cp.CurrentPassword.Equals(cp.NewPassword))
                {
                    ModelState.AddModelError("NewPassword", "New password cannot be same as current password");
                }
                else
                {
                    user.Password = cp.NewPassword;
                    _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    _context.SaveChanges();
                    ViewData["message"] = "Password updated successfully";
                }
            }
            return View();
        }
    }
}