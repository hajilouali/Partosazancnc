using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models;
using Partosazancnc.Tools;

namespace Partosazancnc.Controllers
{
    [RoutePrefix("")]
    public class SiteMapController : Controller
    {
        MyContext db = new MyContext();
        // GET: SiteMap
        [Route("sitemap.xml")]
        public ActionResult Index()
        {
            Sitemap sm = new Sitemap();
            sm.Add(new Location()
            {
                Url = ConfigurationManager.AppSettings["MyDomain"],
                LastModified = DateTime.UtcNow,
                ChangeFrequency = Location.eChangeFrequency.weekly,
                Priority = 1
            });
            sm.Add(new Location()
            {
                Url = ConfigurationManager.AppSettings["MyDomain"] + "ContactUs/",
                LastModified = DateTime.UtcNow,
                ChangeFrequency = Location.eChangeFrequency.monthly,
                Priority = 0.5
            });
            foreach (var VARIABLE in db.Products.Where(p => p.Vaziaat== Vaziaat.Publish))
            {
                sm.Add(new Location()
                {
                    Url = ConfigurationManager.AppSettings["MyDomain"] + "Product/" + VARIABLE.ProductID,
                    LastModified = VARIABLE.Date,
                    ChangeFrequency = Location.eChangeFrequency.daily,
                    Priority = 1,

                });
            }
            foreach (var VARIABLE in db.Posts.Where(p => p.Vaziaat == Vaziaat.Publish))
            {
                sm.Add(new Location()
                {
                    Url = ConfigurationManager.AppSettings["MyDomain"] + "Post/" + VARIABLE.PostID,
                    LastModified = VARIABLE.PostDate,
                    ChangeFrequency = Location.eChangeFrequency.monthly,
                    Priority = 0.9,

                });
            }
            foreach (var VARIABLE in db.Pageses.Where(p => p.Vaziaat == Vaziaat.Publish))
            {
                sm.Add(new Location()
                {
                    Url = ConfigurationManager.AppSettings["MyDomain"] + "page/" + VARIABLE.PageID,
                    LastModified = DateTime.UtcNow,
                    ChangeFrequency = Location.eChangeFrequency.yearly,
                    Priority = 0.8,

                });
            }

            return new XmlResult(sm);
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