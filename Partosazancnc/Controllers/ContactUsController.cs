using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoormatSite.Tools;
using Partosazancnc.Models;
using Partosazancnc.Models.ViewModels;
using Partosazancnc.Tools;

namespace Partosazancnc.Controllers
{
    public class ContactUsController : Controller
    {
        MyContext db = new MyContext();
        // GET: ContactUs
        public ActionResult Index()
        {
            ViewBag.aboutus = DoormatSite.Tools.xml.loadline("siteSetting/siteDiscription");
            ViewBag.address = DoormatSite.Tools.xml.loadline("contact/address");
            ViewBag.phone = DoormatSite.Tools.xml.loadline("contact/Phone");
            
            ViewBag.Sitekeyword = xml.loadline("siteSetting/sitekeywords");
            ViewBag.sitedescription = xml.loadline("siteSetting/siteDiscription");
            return View();
        }

        public ActionResult FormContactus()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool FormContactus(ContactusViewModel model, string SiteKey)
        {
            if (ModelState.IsValid)
            {
                if (reCapchaCheker.isValid(SiteKey))
                {
                    db.ContactUsMessages.Add(new ContactUsMessage()
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        DateSend = DateTime.Now,
                        Message = model.Message,
                        Subject = model.Subject,
                        Vaziaat = Vaziaat.UnReade
                    });
                    db.SaveChanges();
                    return true;
                }
                return false;
            }

            return false;
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