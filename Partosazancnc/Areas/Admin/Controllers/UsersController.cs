using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Partosazancnc.Models;

namespace Partosazancnc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Admin/Users
        public ActionResult Index()
        {
            var userses = db.Userses.Include(u => u.Roles);
            return View(userses.ToList());
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roleses, "RoleID", "RoleTitle");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,RoleID,FullName,UserName,Email,Password,ActiveCode,IsActive,RegisterDate,PhoneNumer")] Users users)
        {
            if (ModelState.IsValid)
            {
                users.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(users.Password, "MD5");
                users.ActiveCode = Guid.NewGuid().ToString();
                users.RegisterDate = DateTime.Now;
                db.Userses.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roleses, "RoleID", "RoleTitle", users.RoleID);
            return View(users);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Userses.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roleses, "RoleID", "RoleTitle", users.RoleID);
            return View(users);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,RoleID,FullName,UserName,Email,Password,ActiveCode,IsActive,RegisterDate,PhoneNumer")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roleses, "RoleID", "RoleTitle", users.RoleID);
            return View(users);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Userses.Find(id);
            foreach (var item in db.Pageses.Where(p => p.UserID == id))
            {
                item.UserID = null;
                db.Entry(item).State = EntityState.Modified;
            }
            foreach (var item in db.Products.Where(p => p.UserID == id))
            {
                item.UserID = null;
                db.Entry(item).State = EntityState.Modified;
            }
            foreach (var item in db.Posts.Where(p => p.UserID == id))
            {
                item.UserID = null;
                db.Entry(item).State = EntityState.Modified;
            }

            db.Userses.Remove(users);
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
