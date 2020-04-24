using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models;
using Tools;

namespace Partosazancnc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FaqsController : Controller
    {
        private MyContext db = new MyContext();

        #region FaqCrud


        // GET: Admin/Faqs
        public ActionResult Index()
        {
            var faqses = db.Faqses.Include(f => f.ProductType);
            return View(faqses.ToList());
        }

        // GET: Admin/Faqs/Details/5


        // GET: Admin/Faqs/Create
        public ActionResult Create()
        {
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "Title");
            return PartialView();
        }

        // POST: Admin/Faqs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaqsID,FaqsTitle,FaqsDiscription,ProductTypeId")] Faqs faqs)
        {
            if (ModelState.IsValid)
            {
                db.Faqses.Add(faqs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "Title", faqs.ProductTypeId);
            return View(faqs);
        }

        // GET: Admin/Faqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faqs faqs = db.Faqses.Find(id);
            if (faqs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "Title", faqs.ProductTypeId);
            return PartialView(faqs);
        }

        // POST: Admin/Faqs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaqsID,FaqsTitle,FaqsDiscription,ProductTypeId")] Faqs faqs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faqs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "Title", faqs.ProductTypeId);
            return RedirectToAction("Index");
        }

        // GET: Admin/Faqs/Delete/5

        public bool DeleteConfirmed(int id)
        {
            Faqs faqs = db.Faqses.Find(id);
            db.Faqses.Remove(faqs);
            db.SaveChanges();
            return true;
        }

        #endregion

        #region UserFaq

        public ActionResult UserFaq()
        {
            return View();
        }

        public ActionResult UserFaqResult(int pageId = 1, string Title = "")
        {
            ViewBag.productTitle = Title;
            ViewBag.pageId = pageId;
            var prodducts = db.UserFaqses.OrderByDescending(p => p.Qdate).ToList();
            if (!string.IsNullOrEmpty(Title))
            {
                prodducts = prodducts.Where(p => p.UserName.Contains(Title)|| p.UserEmail.Contains(Title)|| p.UserQuestion.Contains(Title)).ToList();
            }

            int take = 15;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(prodducts.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return PartialView(prodducts.Skip(skip).Take(take));
        }
        public ActionResult CommentEdite(int id)
        {
            UserFaqs model = db.UserFaqses.Find(id);
            model.Vaziaat = Vaziaat.Reade;
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();

            return PartialView(model);
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CommentEdite(string message, string Email)
        {
            if (ModelState.IsValid)
            {
                SendEmail.Send(Email, "پاسخ به پیغام شما", message);
            }
            return RedirectToAction("UserFaq");
        }

        public bool PublishComment(int id)
        {
            var Post = db.UserFaqses.Find(id);
            if (Post != null)
            {
                Post.Vaziaat = Vaziaat.Reade;
                db.UserFaqses.AddOrUpdate(Post);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool DraftComment(int id)
        {
            var Post = db.UserFaqses.Find(id);
            if (Post != null)
            {
                Post.Vaziaat = Vaziaat.UnReade;
                db.UserFaqses.AddOrUpdate(Post);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool DeleteComment(int id)
        {
            var Post = db.UserFaqses.Find(id);
            if (Post != null)
            {
                db.UserFaqses.Remove(Post);
                db.SaveChanges();
                return true;
            }
            return false;

        }


        #endregion
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
