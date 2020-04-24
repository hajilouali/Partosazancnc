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

namespace Partosazancnc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostTypesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Admin/PostTypes
        public ActionResult Index()
        {
            return View(db.PostTypes.ToList());
        }

       
        // GET: Admin/PostTypes/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/PostTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostTypeID,Title")] PostType postType)
        {
            if (ModelState.IsValid)
            {
                db.PostTypes.Add(postType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postType);
        }

        // GET: Admin/PostTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostType postType = db.PostTypes.Find(id);
            if (postType == null)
            {
                return HttpNotFound();
            }
            return PartialView(postType);
        }

        // POST: Admin/PostTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostTypeID,Title")] PostType postType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postType);
        }

       

      
        public bool DeleteConfirmed(int id)
        {
            PostType postType = db.PostTypes.Find(id);
            foreach (var item in db.Posts.Where(p=>p.PostTypeID==id))
            {
                item.PostTypeID = null;
                db.Posts.AddOrUpdate(item);
            }
            db.PostTypes.Remove(postType);
            db.SaveChanges();
            return true;
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
