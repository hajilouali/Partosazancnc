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
    public class WellcomeController : Controller
    {
        // GET: Admin/Wellcome
        public ActionResult Index()
        {
           
            return View(new WellComeViewModel(){Text = xml.loadline("home/Wellcome") });
        }

        [HttpPost]
        public ActionResult Index(WellComeViewModel Mytext)
        {
            if (ModelState.IsValid)
            {
                xml.SavetoXml("home/Wellcome", Mytext.Text);
            }
            return View(new WellComeViewModel() { Text = xml.loadline("home/Wellcome") });
        }
    }
}