using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoormatSite.Tools;
using Partosazancnc.Models.ViewModels;

namespace Partosazancnc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeaturesController : Controller
    {

        // GET: Admin/Features
        public ActionResult Index()
        {

            return View(new FeaturesVewModel() { Text = xml.loadline("home/Features") });
        }

        [HttpPost]
        public ActionResult Index(FeaturesVewModel Mytext)
        {
            if (ModelState.IsValid)
            {
                xml.SavetoXml("home/Features", Mytext.Text);
            }
            return View(new FeaturesVewModel() { Text = xml.loadline("home/Features") });
        }
    }
}