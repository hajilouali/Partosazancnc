using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Partosazancnc.Models;
using Partosazancnc.Models.ViewModels;
using Partosazancnc.Tools;

namespace Partosazancnc.Controllers
{

    public class ManageEmailsController : Controller
    {
       
        // GET: ManageEmails
        public ActionResult ActiviationEmail()
        {
            

            return PartialView();
        }
        public ActionResult RecoveryPassword()
        {
            return PartialView();
        }

        public ActionResult ReplyContactus()
        {

            return PartialView();
        }

        public ActionResult NewsLetter(string activecode, int bodyid)
        {
            ViewBag.activecode = activecode;
            MyContext db = new MyContext();

            ViewBag.pagebody = db.NewsLetterses.Find(bodyid).NewsLetterBody;
            return PartialView();
        }
    }
}