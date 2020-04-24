using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoormatSite.Tools;
using Partosazancnc.Models;
using Partosazancnc.Models.ViewModels;
using Partosazancnc.Tools;

namespace Partosazancnc.Controllers
{
    public class PostController : Controller
    {
        MyContext db = new MyContext();
        // GET: Post
        public ActionResult RecentPostsResult()
        {
            return PartialView(db.Posts.Where(p=>p.Vaziaat==Vaziaat.Publish).OrderByDescending(p => p.PostDate).Take(8));
        }
        [Route("Post/{id}")]
        public ActionResult PostResult(int id)
        {
            
            return View(db.Posts.Find(id));
        }
        [Route("PostArchive")]
        public ActionResult PostArchive()
        {
           
            ViewBag.Groups = db.PostTypes.ToList();
            ViewBag.Sitekeyword = xml.loadline("siteSetting/sitekeywords");
            ViewBag.sitedescription = xml.loadline("siteSetting/siteDiscription");
            return View();

        }
        [Route("PostArchiveResult")]
        public ActionResult PostArchiveResult(int pageId = 1, string Search = "", int Groupsid = 0)
        {
            ViewBag.pageId = pageId;
            ViewBag.productTitle = Search;
            ViewBag.selectGroup = Groupsid;
            ViewBag.Groups = db.PostTypes.ToList();
            List<Post> list = new List<Post>();


            if (Groupsid != 0)
            {

                list.AddRange(db.Posts.Where(g => g.PostTypeID == Groupsid));


                list.Distinct().ToList();
            }
            else
            {
                list.AddRange(db.Posts.ToList());
            }

            if (!string.IsNullOrEmpty(Search))
            {
                list = list.Where(p =>
                    p.PostTitle.Contains(Search) || p.Users.FullName.Contains(Search) ||
                    p.PostShortDiscription.Contains(Search)).ToList();
            }
            int take = 9;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(list.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return PartialView(list.Where(s => s.Vaziaat == Vaziaat.Publish).OrderBy(p => p.PostDate).Skip(skip).Take(take).ToList());
        }

        public ActionResult LastPost()
        {
            return PartialView(db.Posts.Where(p => p.Vaziaat == Vaziaat.Publish).OrderByDescending(p => p.PostDate).Take(4));
        }

        public ActionResult PostComments(int id)
        {
            return PartialView(db.PostCommentses.Where(p=>p.PostID==id&&p.Vaziaat==Vaziaat.Publish).ToList());
        }
        [HttpGet]
        public ActionResult SendPostCommet(int id )
        {
            ViewBag.PostId = id;
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool SendPostCommet(SendCommentViewModel Model, string SiteKey, string ParentID,string postID)
        {
            if (reCapchaCheker.isValid(SiteKey))
            {
                if (ModelState.IsValid)
                {
                    Models.PostComments model = new PostComments()
                    {
                        Name = Model.Name,
                        Email = Model.Email,
                        Comment = Model.Comment,
                        CreateDate = DateTime.Now,
                        Vaziaat = Vaziaat.UnReade,
                        PostID = Convert.ToInt32(postID)
                    };
                    if (string.IsNullOrEmpty(ParentID))
                    {
                        model.ParentID = null;
                    }
                    else
                    {
                        model.ParentID = Convert.ToInt32(ParentID);
                    }
                    db.PostCommentses.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            
            return false;
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