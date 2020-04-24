using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models;

namespace Partosazancnc.Controllers
{
    public class ManageErrorsController : Controller
    {
        MyContext db = new MyContext();
        // GET: ManageErrors
        public ActionResult Error404(string aspxerrorpath)

        {
            var rute = db.LinkManagers.Where(p => p.Url == aspxerrorpath.Trim().ToLower()).SingleOrDefault();
            if (rute != null)
            {
                return Redirect(rute.RedirectToUrl);
            }
            else
            {
                return View();

            }
            
        }
        public ActionResult Error500()
        {
            return View();
        }

    }
}