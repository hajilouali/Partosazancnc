using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models;
using Tools;

namespace Partosazancnc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostsController : Controller
    {
        private MyContext db = new MyContext();

        #region Post CRUD
        public ActionResult PostResult(int pageId = 1, string Title = "")
        {
            ViewBag.productTitle = Title;
            ViewBag.pageId = pageId;
            var prodducts = db.Posts.OrderByDescending(p => p.PostDate).ToList();
            if (!string.IsNullOrEmpty(Title))
            {
                prodducts = prodducts.Where(p => p.PostTitle.Contains(Title)).ToList();
            }

            int take = 15;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(prodducts.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return PartialView(prodducts.Skip(skip).Take(take));
        }

        // GET: Admin/Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.PostType).Include(p => p.Users);
            return View(posts.ToList());
        }



        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            ViewBag.PostTypeID = new SelectList(db.PostTypes, "PostTypeID", "Title");
            ViewBag.UserID = new SelectList(db.Userses, "UserID", "FullName");
            Post newPost = new Post()
            {
                PostDate = DateTime.Now,
                UserID = db.Userses.Where(p => p.UserName == User.Identity.Name).SingleOrDefault().UserID,
                PostTitle = "بدون تیتر",
                PostShortDiscription = "بدون توضیحات",
                Vaziaat = Vaziaat.Draft
            };
            db.Posts.Add(newPost);
            db.SaveChanges();
            return View(newPost);
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,PostTitle,PostText,PostTypeID,PostShortDiscription,PostDate,KeyWord,UserID,PostImage,Vaziaat")] Post post, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && CheckContentImage.IsImage(img))
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/posts/") + filename);
                    ImageResizer nrResizer = new ImageResizer();
                    nrResizer.Resize(Server.MapPath("/img/posts/") + filename,
                        Server.MapPath("/img/posts/265×176/") + filename, 265, 176);
                    nrResizer.Resize(Server.MapPath("/img/posts/") + filename,
                                            Server.MapPath("/img/posts/thum/") + filename, 150, 150);

                    post.PostImage = filename;
                }
                else
                {
                    post.PostImage = "nopic.jpg";
                }

                post.UserID = db.Userses.Where(p => p.UserName == User.Identity.Name).SingleOrDefault().UserID;
                post.PostDate = DateTime.Now;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostTypeID = new SelectList(db.PostTypes, "PostTypeID", "Title", post.PostTypeID);
            ViewBag.UserID = new SelectList(db.Userses, "UserID", "FullName", post.UserID);
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostTypeID = new SelectList(db.PostTypes, "PostTypeID", "Title", post.PostTypeID);
            ViewBag.UserID = new SelectList(db.Userses, "UserID", "FullName", post.UserID);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,PostTitle,PostText,PostTypeID,PostShortDiscription,PostDate,KeyWord,UserID,PostImage,Vaziaat")] Post post, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && CheckContentImage.IsImage(img))
                {
                    if (!post.PostImage.Contains("nopic"))
                    {
                        System.IO.File.Delete(Server.MapPath("/img/posts/") + post.PostImage);
                        System.IO.File.Delete(Server.MapPath("/img/posts/265×176/") + post.PostImage);
                        System.IO.File.Delete(Server.MapPath("/img/posts/thum/") + post.PostImage);
                    }
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/posts/") + filename);
                    ImageResizer nrResizer = new ImageResizer();
                    nrResizer.Resize(Server.MapPath("/img/posts/") + filename,
                        Server.MapPath("/img/posts/265×176/") + filename, 265, 176);
                    nrResizer.Resize(Server.MapPath("/img/posts/") + filename,
                        Server.MapPath("/img/posts/thum/") + filename, 150, 150);

                    post.PostImage = filename;
                }
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostTypeID = new SelectList(db.PostTypes, "PostTypeID", "Title", post.PostTypeID);
            ViewBag.UserID = new SelectList(db.Userses, "UserID", "FullName", post.UserID);
            return View(post);
        }
        public bool DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return false;
            }
            if (!post.PostImage.Contains("nopic"))
            {
                System.IO.File.Delete(Server.MapPath("/img/posts/") + post.PostImage);
                System.IO.File.Delete(Server.MapPath("/img/posts/265×176/") + post.PostImage);
                System.IO.File.Delete(Server.MapPath("/img/posts/thum/") + post.PostImage);
            }

            foreach (var item in db.PostCommentses.Where(p=>p.PostID==id))
            {
                db.PostCommentses.Remove(item);
            }
            db.Posts.Remove(post);
            db.SaveChanges();
            return true;
        }


        #endregion

        #region PostComment
        public ActionResult PostCommentManage()
        {
            return View();
        }
        public ActionResult PostCommentResult(int pageId=1)
        {
            ViewBag.pageId = pageId;
            var prodducts = db.PostCommentses.OrderByDescending(p => p.CreateDate).ToList();
            
            int take = 10;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(prodducts.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return PartialView(prodducts.Skip(skip).Take(take));
        }

        public ActionResult CommentEdite(int id)
        {
            PostComments model = db.PostCommentses.Find(id);
            if (model.ParentID!=null)
            {
                ViewBag.parenttext = db.PostCommentses.Find(model.ParentID).Comment;
            }
            return PartialView(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentEdite(PostComments Model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PostCommentManage");
            }
            return RedirectToAction("PostCommentManage");
        }

        public bool PublishComment(int id)
        {
            var Post = db.PostCommentses.Find(id);
            if (Post!=null)
            {
                Post.Vaziaat = Vaziaat.Publish;
                db.PostCommentses.AddOrUpdate(Post);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool DraftComment(int id)
        {
            var Post = db.PostCommentses.Find(id);
            if (Post != null)
            {
                Post.Vaziaat = Vaziaat.UnReade;
                db.PostCommentses.AddOrUpdate(Post);
                db.SaveChanges();
                return true;
            }
            return false;

        }
        
        public bool DeleteComment(int id)
        {
            var Post = db.PostCommentses.Find(id);
            if (Post != null)
            {
                db.PostCommentses.Remove(Post);
                db.SaveChanges();
                return true;
            }
            return false;

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
