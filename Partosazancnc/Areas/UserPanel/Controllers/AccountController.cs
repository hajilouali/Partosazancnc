using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Partosazancnc.Models;
using Partosazancnc.Models.ViewModels;

namespace Partosazancnc.Areas.UserPanel.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        MyContext db = new MyContext();
        // GET: UserPanel/Account
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel change)
        {
            if (ModelState.IsValid)
            {
                var user = db.Userses.Single(u => u.UserName == User.Identity.Name);
                string oldPasswordHash =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(change.OldPassword, "MD5");
                if (user.Password == oldPasswordHash)
                {
                    string hashNewPasword =
                        FormsAuthentication.HashPasswordForStoringInConfigFile(change.Password, "MD5");
                    user.Password = hashNewPasword;
                    db.SaveChanges();
                    ViewBag.Success = true;
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "کلمه عبور فعلی درست نمی باشد");
                }
            }
            return View();
        }

        public ActionResult ChangeInfo()
        {
            Users user = db.Userses.Single(u => u.UserName == User.Identity.Name);
            ChangeAccountInfoViewModel model = new ChangeAccountInfoViewModel()
            {
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumer
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeInfo(ChangeAccountInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = db.Userses.Single(u => u.UserName == User.Identity.Name);
                user.FullName = model.FullName;
                user.PhoneNumer = model.PhoneNumber;
                db.SaveChanges();
                ViewBag.Success = true;
            }
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}