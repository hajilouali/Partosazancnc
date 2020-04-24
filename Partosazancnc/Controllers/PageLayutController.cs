using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoormatSite.Tools;
using MoreLinq;
using Partosazancnc.Models;
using Partosazancnc.Models.ViewModels;
using Partosazancnc.Tools;
using UserFaqs = Partosazancnc.Models.ViewModels.UserFaqs;

namespace Partosazancnc.Controllers
{

    public class PageLayutController : Controller
    {
        private MyContext db = new MyContext();

        #region Header

        #region Faqs

        [Route("Faqs")]
        public ActionResult Faqs(string faqs = "false")
        {
            ViewBag.succesfaq = faqs;
            return View();
        }

        public ActionResult fagresult()
        {

            List<Faqs> faq = db.Faqses.DistinctBy(P => P.ProductType.Title).ToList();
            List<string> category = new List<string>();
            foreach (var VARIABLE in faq)
            {
                category.Add(VARIABLE.ProductType.Title);
            }
            ViewBag.category = category;

            return PartialView(db.Faqses.ToList());
        }

        public ActionResult UserFags()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult UserFags(UserFaqs userFaqs, string SiteKey)
        {
            if (reCapchaCheker.isValid(SiteKey))
            {
                if (ModelState.IsValid)
                {
                    db.UserFaqses.Add(new Models.UserFaqs()
                    {
                        UserName = userFaqs.YourName,
                        UserEmail = userFaqs.Email,
                        UserQuestion = userFaqs.Questions,
                        Vaziaat = Vaziaat.UnReade,
                        Qdate = DateTime.Now
                    });
                    db.SaveChanges();
                    ViewBag.succesfaq = true;
                    return Redirect("/faqs?faqs=true");
                }
            }
            
            
            return Redirect("/Faqs");
        }

        #endregion

        #region Menu

        public ActionResult NavbaResult()
        {
            ViewBag.Logo = xml.loadline("siteSetting/logo");
            return PartialView(db.Menus.ToList());
        }

       
        #endregion

        #endregion

        #region Footer

        #region SubFooter

        public ActionResult FooteResult()
        {
            ViewBag.Logo = xml.loadline("siteSetting/logo");
            ViewBag.SiteName = xml.loadline("siteSetting/siteName");
            ViewBag.AbloutUs = xml.loadline("siteSetting/siteDiscription");
            ViewBag.Address = xml.loadline("contact/address");
            ViewBag.Phone = xml.loadline("contact/Phone");
            ViewBag.Email = xml.loadline("contact/email");
            ViewBag.FaceBook = xml.loadline("contact/FaceBook");
            ViewBag.Instagram = xml.loadline("contact/Instagram");
            ViewBag.Telegram = xml.loadline("contact/Telegram");

            List<PostLinkViewModel> postLink = db.Posts.Where(p=>p.Vaziaat==Vaziaat.Publish).OrderByDescending(p => p.PostDate).Take(3).Select(f =>
                new PostLinkViewModel()
                {
                    DateTime = f.PostDate,
                    PostTitle = f.PostTitle,
                    Url = "/Post/" + f.PostID
                }).ToList();
            List<PostLinkViewModel> meList = db.Menus.Where(s => s.ParentID == 0).OrderBy(p => p.MenusID).Select(f =>
                    new PostLinkViewModel()
                    {
                        PostTitle = f.MenuTitle,
                        Url = f.URL
                    }).ToList();

            ViewBag.postLink = postLink;
            ViewBag.MeList = meList;

            return PartialView();
        }

        [Route("newsletter")]
        public bool newsletter(string email, string SiteKeyNews)
        {
            if (reCapchaCheker.isValid(SiteKeyNews))
            {
                if (ModelState.IsValid)
                {
                    if (!db.NewsLettersMails.Where(p => p.Email == email).Any())
                    {
                        NewsLettersMail lettersMail = new NewsLettersMail()
                        {
                            Email = email,
                            SubmitTime = DateTime.Now,
                            DeActivatCode = Guid.NewGuid().ToString()
                        };
                        db.NewsLettersMails.Add(lettersMail);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    return false;
                }
            }
            return false;
        }

        #endregion

        #endregion
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: PageLayut

    }
}