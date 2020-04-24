using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoormatSite.Tools;
using Partosazancnc.Models;
using Tools;

namespace Partosazancnc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NewsLetterController : Controller
    {
        MyContext db = new MyContext();
        // GET: Admin/NewsLetter

        #region NewsLater

        public ActionResult Index()
        {
            return View(db.NewsLetterses.ToList());
        }

        public ActionResult CreateNewsLetter()
        {
            ViewBag.NewsLetterListId = new SelectList(db.NewsLetterLists, "NewsLetterListId", "NewsLetterListTitle");
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewsLetter(NewsLetters model, List<string> ckselect, string timesend, string datesend)
        {
            if (ModelState.IsValid)
            {
                if (ckselect != null)
                {
                    foreach (var iten in ckselect)
                    {
                        model.Days += iten + ",";
                    }
                }
                if (!string.IsNullOrEmpty(timesend))
                {
                    if (string.IsNullOrEmpty(datesend))
                    {

                        timesend = Convert.ToDateTime(timesend).ToShortTimeString();
                        model.DateTime = Convert.ToDateTime(Convert.ToDateTime("1380/01/01").ToShortDateString() + " " + timesend);
                        db.NewsLetterses.Add(model);
                        db.SaveChanges();
                    }
                    else
                    {
                        datesend = Convert.ToDateTime(datesend).ToShortDateString();
                        timesend = Convert.ToDateTime(timesend).ToShortTimeString();
                        model.DateTime = Convert.ToDateTime(datesend + " " + timesend);
                        db.NewsLetterses.Add(model);
                        db.SaveChanges();
                    }
                }
                else
                {
                    model.DateTime = DateTime.Now;
                    model.IsActive = true;
                    db.NewsLetterses.Add(model);
                    db.SaveChanges();
                    foreach (var item in db.NewsLetterMembers.Where(p => p.NewsLetterListId == model.NewsLetterListId))
                    {
                        string to = item.NewsLettersMail.Email;
                        string sub = "خبرنامه  " + "-" + xml.loadline("siteSetting/siteName");
                        string body = PartialToStringClass.urltostring(ConfigurationManager.AppSettings["MyDomain"] + "/ManageEmails/NewsLetter?activecode=" + item.NewsLettersMail.DeActivatCode + "&bodyid=" + model.NewsLetterId);
                        SendEmail.Send(to, sub, body);
                    }

                }
               
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);

        }


        public ActionResult EditeNewsLetter(int id)
        {
            var model = db.NewsLetterses.Find(id);
            ViewBag.NewsLetterListId = new SelectList(db.NewsLetterLists, "NewsLetterListId", "NewsLetterListTitle", model.NewsLetterListId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditeNewsLetter(NewsLetters model, List<string> ckselect, string timesend, string datesend)
        {

            if (ModelState.IsValid)
            {
                if (ckselect != null)
                {
                    foreach (var iten in ckselect)
                    {
                        model.Days += iten + ",";
                    }
                }
                if (!string.IsNullOrEmpty(timesend))
                {
                    if (string.IsNullOrEmpty(datesend))
                    {

                        timesend = Convert.ToDateTime(timesend).ToShortTimeString();
                        model.DateTime = Convert.ToDateTime(Convert.ToDateTime("1380/01/01").ToShortDateString() + " " + timesend);
                    }
                    else
                    {
                        datesend = Convert.ToDateTime(datesend).ToShortDateString();
                        timesend = Convert.ToDateTime(timesend).ToShortTimeString();
                        model.DateTime = Convert.ToDateTime(datesend + " " + timesend);
                    }
                }
                else
                {
                    model.DateTime = DateTime.Now;
                    foreach (var item in db.NewsLetterMembers.Where(p => p.NewsLetterListId == model.NewsLetterId))
                    {
                        SendEmail.Send(item.NewsLettersMail.Email, "خبر نامه " + xml.loadline("siteSetting/siteName") + "-" + DateTime.Now.Date, model.NewsLetterBody);
                    }

                }

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NewsLetterListId = new SelectList(db.NewsLetterLists, "NewsLetterListId", "NewsLetterListTitle", model.NewsLetterListId);
            return View(model);
        }

        public void DeleteNewsLetter(int id)
        {
            try
            {
                db.NewsLetterses.Remove(db.NewsLetterses.Find(id));
                db.SaveChanges();
            }
            catch
            {

            }
        }
        public void PublishNewsLetter(int id)
        {
            var model = db.NewsLetterses.Find(id);
            try
            {
                model.IsActive = true;
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {

            }
        }
        public void DraftNewsLetter(int id)
        {
            var model = db.NewsLetterses.Find(id);
            try
            {
                model.IsActive = false;
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {

            }
        }

        #endregion

        #region NewsLeterList

        public ActionResult Lists()
        {
            return View(db.NewsLetterLists.ToList());
        }

        public ActionResult CreateList()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateList(NewsLetterList model)
        {
            if (ModelState.IsValid)
            {
                db.NewsLetterLists.Add(model);
                db.SaveChanges();
                return RedirectToAction("Lists");
            }

            return PartialView(model);
        }

        public ActionResult EditList(int id)
        {
            return PartialView(db.NewsLetterLists.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditList(NewsLetterList model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Lists");
            }

            return PartialView(model);
        }

        public void DeleteList(int id)
        {
            foreach (var VARIABLE in db.NewsLetterMembers.Where(p=>p.NewsLetterListId==id))
            {
                db.NewsLetterMembers.Remove(VARIABLE);
            }

            db.NewsLetterLists.Remove(db.NewsLetterLists.Find(id));
            db.SaveChanges();
        }

        public ActionResult ListMemmber(int id)
        {
            ViewBag.listtitle = db.NewsLetterLists.Find(id).NewsLetterListTitle;
            ViewBag.id = id;
            return View();
        }
        public ActionResult ListMemmberResult(int id, int pageId = 1, string Title = "")
        {
            var model = db.NewsLetterMembers.Where(p=>p.NewsLetterListId==id).ToList();
            List<NewsLettersMail> result=new List<NewsLettersMail>();
            foreach (var item in model)
            {
                result.Add(db.NewsLettersMails.Find(item.NewsLettersMailID));
            }



            ViewBag.productTitle = Title;
            ViewBag.pageId = pageId;
            if (!string.IsNullOrEmpty(Title))
            {
                result = result.Where(p => p.Email.Contains(Title)).ToList();
            }

            int take = 15;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(result.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;

            return PartialView(result.Skip(skip).Take(take));
        }

        public ActionResult addMembertolist(int id, int pageId = 1)
        {
            ViewBag.idlist = id;
            var model = db.NewsLettersMails.ToList();
            List<NewsLettersMail> result = new List<NewsLettersMail>();
            foreach (var item in model)
            {
                if (!item.NewsLetterMembers.Where(p=>p.NewsLetterListId==id).Any())
                {
                result.Add(item);
                }
            }





            ViewBag.pageId = pageId;
            

            int take = 15;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(result.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return PartialView(result.Skip(skip).Take(take));
        }

        public void AddMembertolistfromlist(int id, List<int> mail)
        {
            if (mail!=null)
            {
                foreach (var itemm in mail)
                {
                    db.NewsLetterMembers.Add(new NewsLetterMember()
                    {
                        NewsLetterListId = id,
                        NewsLettersMailID = itemm
                    });
                }

                db.SaveChanges();
            }
        }

        public void removeMember(int list, int mail)
        {
            var model = db.NewsLetterMembers.Where(a => a.NewsLetterListId == list && a.NewsLettersMailID==mail);
            if (model!=null)
            {
                foreach (var VARIABLE in model)
                {
                    db.NewsLetterMembers.Remove(VARIABLE);

                }

                db.SaveChanges();
            }
            
        }
        #endregion

        #region newsLetterMails

        public ActionResult Emails()
        {
            return View();
        }

        public ActionResult EmailsResult(int pageId = 1, string Title = "")
        {
            ViewBag.productTitle = Title;
            ViewBag.pageId = pageId;
            var prodducts = db.NewsLettersMails.OrderByDescending(p => p.SubmitTime).ToList();
            if (!string.IsNullOrEmpty(Title))
            {
                prodducts = prodducts.Where(p => p.Email.Contains(Title)).ToList();
            }

            int take = 20;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(prodducts.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return PartialView(prodducts.Skip(skip).Take(take));
        }

        public ActionResult NewEmail()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewEmail(NewsLettersMail model)
        {
            if (ModelState.IsValid)
            {
                if (!db.NewsLettersMails.Where(p=>p.Email.ToLower()==model.Email).Any())
                {
                    model.SubmitTime = DateTime.Now;
                    model.DeActivatCode = Guid.NewGuid().ToString();
                    db.NewsLettersMails.Add(model);
                    db.SaveChanges();
                }
               
                return RedirectToAction("Emails");
            }
            return PartialView(model);
        }

        public ActionResult EditEmail(int id)
        {
            return PartialView(db.NewsLettersMails.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmail(NewsLettersMail model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Emails");
            }

            return PartialView(model);
        }

        public void DeleteEmail(int id)
        {
            var model = db.NewsLettersMails.Find(id);
            foreach (var VARIABLE in db.NewsLetterMembers.Where(p=>p.NewsLettersMailID==id))
            {
                db.NewsLetterMembers.Remove(VARIABLE);
            }

            db.NewsLettersMails.Remove(model);
            db.SaveChanges();
        }
        [AllowAnonymous]
        [Route("DeactiveNewsLetter")]
        public ActionResult DeactiveNewsLetter(string DeActiveCode)
        {
            var model = db.NewsLettersMails.Where(p => p.DeActivatCode == DeActiveCode).SingleOrDefault();
            if (model==null)
            {
                ViewBag.result = false;
                return View();
            }

            foreach (var VARIABLE in db.NewsLetterMembers.Where(s=>s.NewsLettersMailID==model.NewsLettersMailID).ToList())
            {
                db.NewsLetterMembers.Remove(VARIABLE);
            }
            db.NewsLettersMails.Remove(model);
            db.SaveChanges();
            ViewBag.result = true;
            return View(model);
        }
        #endregion
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