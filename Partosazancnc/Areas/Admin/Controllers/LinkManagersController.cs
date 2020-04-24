using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models;

namespace Partosazancnc.Areas.Admin.Controllers
{
    public class LinkManagersController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Admin/LinkManagers
        public ActionResult Index()
        {
            return View(db.LinkManagers.ToList());
        }

      

        // GET: Admin/LinkManagers/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/LinkManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LinkMAnagerId,ReDirectName,Url,RedirectToUrl")] LinkManager linkManager)
        {
            if (ModelState.IsValid)
            {
                linkManager.RedirectToUrl = linkManager.RedirectToUrl.Trim().ToLower();
                db.LinkManagers.Add(linkManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView(linkManager);
        }

        // GET: Admin/LinkManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinkManager linkManager = db.LinkManagers.Find(id);
            if (linkManager == null)
            {
                return HttpNotFound();
            }
            return PartialView(linkManager);
        }

        // POST: Admin/LinkManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LinkMAnagerId,ReDirectName,Url,RedirectToUrl")] LinkManager linkManager)
        {
            if (ModelState.IsValid)
            {
                linkManager.RedirectToUrl = linkManager.RedirectToUrl.Trim().ToLower();
                db.Entry(linkManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(linkManager);
        }

       

        // POST: Admin/LinkManagers/Delete/5
        
        public bool DeleteConfirmed(int id)
        {
            try
            {
                LinkManager linkManager = db.LinkManagers.Find(id);
                db.LinkManagers.Remove(linkManager);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //[Route("{path}")]
        //public ActionResult redirecturl(string path)

        //{

        //    var rute = db.LinkManagers.Where(p => p.Url == path.Trim().ToLower()).SingleOrDefault();
        //    if (rute != null)
        //    {
        //        redirecturl(rute.RedirectToUrl);
        //    }

        //    return HttpNotFound();
        //}
    }
}
