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
    public class ProductController : Controller
    {
        private MyContext db = new MyContext();
        // GET: Product
        [Route("ProductArchive")]
        public ActionResult ProductArchive(int pageId = 1, int ProductCategory=0, string Search = "")
        {
            ViewBag.Sitekeyword = xml.loadline("siteSetting/sitekeywords");
            ViewBag.sitedescription = xml.loadline("siteSetting/siteDiscription");
            ViewBag.pageId = pageId;
            ViewBag.selectGroup = ProductCategory;
            ViewBag.productTitle = Search;
            ViewBag.Groups = db.ProductTypes.ToList();
            List<Product> list = new List<Product>();


            if (ProductCategory != 0)
            {

                list.AddRange(db.Products.Where(g => g.ProductTypeId == ProductCategory));


                list.Distinct().ToList();
            }
            else
            {
                list.AddRange(db.Products.ToList());
            }

            if (!string.IsNullOrEmpty(Search))
            {
                list = list.Where(p =>
                    p.Title.Contains(Search) || p.Users.FullName.Contains(Search) ||
                    p.ShortDiscription.Contains(Search)).ToList();
            }
            int take = 9;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(list.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return View(list.Where(s => s.Vaziaat == Vaziaat.Publish).OrderBy(p => p.Date).Skip(skip).Take(take).ToList());
        }

        [Route("Product/{id}")]
        public ActionResult ProductResult(int id)
        {
            var model = db.Products.Find(id);
            ViewBag.property = db.ProductProperties.Where(p => p.ProductID == id).ToList();
            ViewBag.Attachment = db.ProductAttachFiles.Where(p => p.ProductID == id).ToList();


            if (model.Vaziaat!=Vaziaat.Publish)
            {
                HttpNotFound();
            }
            return View(model);
        }

        public ActionResult ProductComments(int id)
        {
            return PartialView(db.ProductCommentses.Where(p => p.ProductID == id && p.Vaziaat == Vaziaat.Publish).ToList());
        }
        [HttpGet]
        public ActionResult SendProductCommet(int id)
        {
            ViewBag.PostId = id;
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool SendProductCommet(SendCommentViewModel Model, string SiteKey, string ParentID, string postID)
        {
            if (reCapchaCheker.isValid(SiteKey))
            {
                if (ModelState.IsValid)
                {
                    Models.ProductComments model = new ProductComments()
                    {
                        Name = Model.Name,
                        Email = Model.Email,
                        Comment = Model.Comment,
                        CreateDate = DateTime.Now,
                        Vaziaat = Vaziaat.UnReade,
                        ProductID = Convert.ToInt32(postID)
                    };
                    if (string.IsNullOrEmpty(ParentID))
                    {
                        model.ParentID = null;
                    }
                    else
                    {
                        model.ParentID = Convert.ToInt32(ParentID);
                    }
                    db.ProductCommentses.Add(model);
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