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
    public class BrandsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Admin/Brands
        public ActionResult Index()
        {
            return View(db.Brandses.ToList());
        }

        // GET: Admin/Brands/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Brands brands = db.Brandses.Find(id);
        //    if (brands == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(brands);
        //}

        // GET: Admin/Brands/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrandID,BrandName,Image")] Brands brands,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img!=null&&CheckContentImage.IsImage(img))
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/")+filename);
                    brands.Image = filename;
                    db.Brandses.Add(brands);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            return View(brands);
        }

        // GET: Admin/Brands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brands brands = db.Brandses.Find(id);
            if (brands == null)
            {
                return HttpNotFound();
            }
            return PartialView(brands);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrandID,BrandName,Image")] Brands brands,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img!=null&&CheckContentImage.IsImage(img))
                {
                    if (!string.IsNullOrEmpty(brands.Image))
                    {
                        System.IO.File.Delete(Server.MapPath("/img/")+brands.Image);
                    }
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/") + filename);
                    brands.Image = filename;
                }
                db.Entry(brands).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brands);
        }

        // GET: Admin/Brands/Delete/5
      

        // POST: Admin/Brands/Delete/5
       
        
        public bool DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                
                Brands brands = db.Brandses.Find(id);
                if (!string.IsNullOrEmpty(brands.Image))
                {
                    System.IO.File.Delete(Server.MapPath("/img/")+brands.Image);
                }
                db.Brandses.Remove(brands);
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
