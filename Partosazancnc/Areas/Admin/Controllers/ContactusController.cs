using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models;
using Tools;

namespace Partosazancnc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactusController : Controller
    {
        MyContext db = new MyContext();
        // GET: Admin/Contactus
        public ActionResult list()
        {
            return View();
        }

        public ActionResult ListResult(int pageId = 1, string Title = "")
        {
            ViewBag.productTitle = Title;
            ViewBag.pageId = pageId;
            var prodducts = db.ContactUsMessages.OrderByDescending(p => p.DateSend).ToList();
            if (!string.IsNullOrEmpty(Title))
            {
                prodducts = prodducts.Where(p => p.Name.Contains(Title)).ToList();
            }

            int take = 15;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(prodducts.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return PartialView(prodducts.Skip(skip).Take(take));
        }

        public ActionResult CommentEdite(int id)
        {
            ContactUsMessage model = db.ContactUsMessages.Find(id);
            model.Vaziaat = Vaziaat.Reade;
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();

            return PartialView(model);
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CommentEdite(string message , string Email)
        {
            if (ModelState.IsValid)
            {
                SendEmail.Send(Email,"پاسخ به پیغام شما", message);
            }
            return RedirectToAction("list");
        }

        public bool PublishComment(int id)
        {
            var Post = db.ContactUsMessages.Find(id);
            if (Post != null)
            {
                Post.Vaziaat = Vaziaat.Reade;
                db.ContactUsMessages.AddOrUpdate(Post);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool DraftComment(int id)
        {
            var Post = db.ContactUsMessages.Find(id);
            if (Post != null)
            {
                Post.Vaziaat = Vaziaat.UnReade;
                db.ContactUsMessages.AddOrUpdate(Post);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool DeleteComment(int id)
        {
            var Post = db.ContactUsMessages.Find(id);
            if (Post != null)
            {
                db.ContactUsMessages.Remove(Post);
                db.SaveChanges();
                return true;
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