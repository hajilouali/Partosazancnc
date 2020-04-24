using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models;

namespace Partosazancnc.Controllers
{
    public class PageController : Controller
    {
        private MyContext db = new MyContext();
        // GET: Page
        [Route("Page/{id}")]
        public ActionResult PageResult(int id)
        {
            return View(db.Pageses.Find(id));
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