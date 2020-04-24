using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models;
using Tools;

namespace Partosazancnc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PagesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Admin/Pages
        public ActionResult PostResult(int pageId = 1, string Title = "")
        {
            ViewBag.productTitle = Title;
            ViewBag.pageId = pageId;
            var prodducts = db.Pageses.OrderByDescending(p => p.PageID).ToList();
            if (!string.IsNullOrEmpty(Title))
            {
                prodducts = prodducts.Where(p => p.PageTitle.Contains(Title)).ToList();
            }

            int take = 15;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(prodducts.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return PartialView(prodducts.Skip(skip).Take(take));
        }
        public ActionResult Index()
        {
            
            return View();
        }

      

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            
            Pages newPost = new Pages()
            {
                UserID = db.Userses.Where(p => p.UserName == User.Identity.Name).SingleOrDefault().UserID,
                PageTitle = "بدون تیتر",
                PageShortDiscription = "بدون توضیحات",
                Vaziaat = Vaziaat.Draft,
                ImageThumline = "nopic.jpg"
        };
            db.Pageses.Add(newPost);
            db.SaveChanges();
            return View(newPost);
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,PageTitle,PageContent,KeyWord,PageShortDiscription,ImageThumline,UserID,Vaziaat")] Pages pages,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img!=null&&CheckContentImage.IsImage(img))
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/page/")+filename);
                    pages.ImageThumline = filename;
                }
                else
                {
                    pages.ImageThumline = "nopic.jpg";
                }
                db.Entry(pages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Userses, "UserID", "FullName", pages.UserID);
            return View(pages);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pages pages = db.Pageses.Find(id);
            if (pages == null)
            {
                return HttpNotFound();
            }
            return View(pages);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,PageTitle,PageContent,KeyWord,PageShortDiscription,ImageThumline,UserID,Vaziaat")] Pages pages,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img!=null&&CheckContentImage.IsImage(img))
                {
                    if (!pages.ImageThumline.Contains("nopic.jpg"))
                    {
                       System.IO.File.Delete(Server.MapPath("/img/page/")+pages.ImageThumline); 
                    }
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/page/") + filename);
                    pages.ImageThumline = filename;
                }
                db.Entry(pages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Userses, "UserID", "FullName", pages.UserID);
            return View(pages);
        }

       

     
        public ActionResult DeleteConfirmed(int id)
        {
            Pages pages = db.Pageses.Find(id);
            if (!pages.ImageThumline.Contains("nopic.jpg"))
            {
                System.IO.File.Delete(Server.MapPath("/img/Page/")+pages.ImageThumline);
            }
            db.Pageses.Remove(pages);
            db.SaveChanges();
            return RedirectToAction("Index");
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
