using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models;
using DoormatSite.Tools;
using Partosazancnc.Models.ViewModels;
using Quartz.Impl.Triggers;
using Tools;

namespace Partosazancnc.Controllers
{
    public class HomeController : Controller
    {
        MyContext db = new MyContext();

        [HttpPost]
        [Authorize]
        public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor,
            string langCode)
        {
            string vImagePath = String.Empty;
            string vMessage = String.Empty;
            string vFilePath = String.Empty;
            string vOutput = String.Empty;
            try
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var vFileName = DateTime.Now.ToString("yyyyMMdd-HHMMssff") +
                                    Path.GetExtension(upload.FileName).ToLower();
                    var vFolderPath = Server.MapPath("/Upload/");
                    if (!Directory.Exists(vFolderPath))
                    {
                        Directory.CreateDirectory(vFolderPath);
                    }
                    vFilePath = Path.Combine(vFolderPath, vFileName);
                    upload.SaveAs(vFilePath);
                    vImagePath = Url.Content("/Upload/" + vFileName);
                    vMessage = "تصویر با مفقیت ذخیره شد";
                }
            }
            catch
            {
                vMessage = "There was an issue uploading";
            }
            vOutput = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + vImagePath + "\", \"" + vMessage + "\");</script></body></html>";
            return Content(vOutput);
        }
        public ActionResult text()
        {


            string body = PartialToStringClass.urltostring("http://localhost:59485/ManageEmails/NewsLetter?activecode=ssss&bodyid=39");
            return Content(body);
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Catalog = xml.loadline("siteSetting/Catalog");
            ViewBag.Logooo = xml.loadline("siteSetting/logo");
            ViewBag.SiteName = xml.loadline("siteSetting/siteName");
            ViewBag.Sitekeyword = xml.loadline("siteSetting/sitekeywords");
            ViewBag.sitedescription = xml.loadline("siteSetting/siteDiscription");
            string soc = "";
            string car = Convert.ToString('"');
            soc += car + xml.loadline("contact/FaceBook") + car + ",";
            soc += car + xml.loadline("contact/Instagram") + car + ",";
            soc += car + xml.loadline("contact/Telegram") + car ;
            ViewBag.sco = soc;
            return View();
        }

        public ActionResult SLideResult()
        {
            return PartialView(db.Sliderses.Where(p => p.Vaziaat == Vaziaat.Publish).ToList());
        }

        public ActionResult LayerSlider(int sliderid)
        {
            return PartialView(db.LayerSliderses.Where(p => p.SlideID == sliderid).ToList());
        }

        public ActionResult WellcomeResult()
        {
            ViewBag.wellcomeresult = xml.loadline("home/Wellcome");
            return PartialView();
        }

        public ActionResult ProductCategoryResult()
        {
            return PartialView(db.ProductTypes.ToList());
        }

        public ActionResult FeaturesResult()
        {
            ViewBag.FeaturesResult = xml.loadline("home/Features");
            return PartialView();
        }

        public ActionResult ParallaxResult()
        {

            return PartialView(new socialViewModel()
            {
                Instagram = xml.loadline("contact/Instagram"),
                FaceBook = xml.loadline("contact/FaceBook"),
                Aparat = xml.loadline("contact/Aparat"),
                Telegram = xml.loadline("contact/Telegram")
            });
        }

        public ActionResult CostomeResult()
        {
            return PartialView(db.Brandses.ToList());
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