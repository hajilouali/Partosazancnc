using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Partosazancnc.Models;
using Partosazancnc.Models.ViewModels;

namespace Partosazancnc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private MyContext db = new MyContext();
        [Authorize]
        [HttpGet]
        public ActionResult PageLock()
        {
            Users user = db.Userses.Single(a => a.UserName == User.Identity.Name);
            AccountLockViewModel u = new AccountLockViewModel() { FullName = user.FullName, UserName = user.UserName,Email = user.Email};
            FormsAuthentication.SignOut();
            return View(u);
        }

        [HttpPost]
        
        public ActionResult PageLock(AccountLockViewModel u)
        {
            if (ModelState.IsValid)
            {
                string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(u.Password, "MD5");
                Users userfind = db.Userses.SingleOrDefault(a => a.Email == u.Email && a.Password == pass);
                if (userfind != null)
                {
                    FormsAuthentication.SetAuthCookie(userfind.UserName, false);
                    return Redirect("/Admin/");
                }
                else
                {
                  ModelState.AddModelError("Password","رمز عبور وارد شده معتبر نمی باشد!"); 
                }
            }
            return View(u);
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