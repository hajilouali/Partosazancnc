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
    public class ProductsController : Controller
    {
        private MyContext db = new MyContext();
        // GET: Admin/Products
        #region CRUD
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult ProductResult(int pageId = 1, string Title = "")
        {
            ViewBag.productTitle = Title;
            ViewBag.pageId = pageId;
            var prodducts = db.Products.OrderByDescending(p => p.Date).ToList();
            if (!string.IsNullOrEmpty(Title))
            {
                prodducts = prodducts.Where(p => p.Title.Contains(Title)).ToList();
            }

            int take = 15;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(prodducts.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return PartialView(prodducts.Skip(skip).Take(take));
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "Title");
            ViewBag.UserID = new SelectList(db.Userses, "UserID", "FullName");
            Product product = new Product();

            product.Date = DateTime.Now;
            product.UserID = db.Userses.Where(p => p.UserName == User.Identity.Name).SingleOrDefault().UserID;
            product.Title = "بدون تیتر";
            product.ShortDiscription = "بدون توضیحات";
            product.Vaziaat = Vaziaat.Draft;
            product.ProductTypeId = null;
            product.PicThumbnail = "nopic.jpg";


            db.Products.Add(product);
            db.SaveChanges();
            return View(product);
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,UserID,ProductTypeId,Title,ShortDiscription,Text,PicThumbnail,KeyWord,Date,Vaziaat")] Product product, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && CheckContentImage.IsImage(img))
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/Products/") + filename);
                    ImageResizer nrResizer = new ImageResizer();
                    nrResizer.Resize(Server.MapPath("/img/Products/") + filename,
                        Server.MapPath("/img/Products/1000×1500/") + filename, 1000, 1500);
                    nrResizer.Resize(Server.MapPath("/img/Products/") + filename,
                        Server.MapPath("/img/Products/192×288/") + filename, 192, 288);
                    nrResizer.Resize(Server.MapPath("/img/Products/") + filename,
                        Server.MapPath("/img/Products/262×393/") + filename, 262, 393);
                    nrResizer.Resize(Server.MapPath("/img/Products/") + filename,
                        Server.MapPath("/img/Products/thum/") + filename, 150, 150);

                    product.PicThumbnail = filename;
                }
                else
                {
                    product.PicThumbnail = "nopic.jpg";
                }

                product.UserID = db.Userses.Where(p => p.UserName == User.Identity.Name).SingleOrDefault().UserID;
                product.Date = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "Title", product.ProductTypeId);
            ViewBag.UserID = new SelectList(db.Userses, "UserID", "FullName", product.UserID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "Title", product.ProductTypeId);
            ViewBag.UserID = new SelectList(db.Userses, "UserID", "FullName", product.UserID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,UserID,ProductTypeId,Title,ShortDiscription,Text,PicThumbnail,KeyWord,Date,Vaziaat")] Product product, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && CheckContentImage.IsImage(img))
                {
                    if (!product.PicThumbnail.Contains("nopic"))
                    {
                        System.IO.File.Delete(Server.MapPath("/img/Products/") + product.PicThumbnail);
                        System.IO.File.Delete(Server.MapPath("/img/Products/1000×1500/") + product.PicThumbnail);
                        System.IO.File.Delete(Server.MapPath("/img/Products/192×288/") + product.PicThumbnail);
                        System.IO.File.Delete(Server.MapPath("/img/Products/262×393/") + product.PicThumbnail);
                        System.IO.File.Delete(Server.MapPath("/img/Products/thum/") + product.PicThumbnail);
                    }
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/Products/") + filename);
                    ImageResizer nrResizer = new ImageResizer();
                    nrResizer.Resize(Server.MapPath("/img/Products/") + filename,
                        Server.MapPath("/img/Products/1000×1500/") + filename, 1000, 1500);
                    nrResizer.Resize(Server.MapPath("/img/Products/") + filename,
                        Server.MapPath("/img/Products/192×288/") + filename, 192, 288);
                    nrResizer.Resize(Server.MapPath("/img/Products/") + filename,
                        Server.MapPath("/img/Products/262×393/") + filename, 262, 393);
                    nrResizer.Resize(Server.MapPath("/img/Products/") + filename,
                        Server.MapPath("/img/Products/thum/") + filename, 150, 150);

                    product.PicThumbnail = filename;
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ProductTypeId", "Title", product.ProductTypeId);
            ViewBag.UserID = new SelectList(db.Userses, "UserID", "FullName", product.UserID);
            return View(product);
        }

        public bool DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return false;
            }
            if (!product.PicThumbnail.Contains("nopic"))
            {
                System.IO.File.Delete(Server.MapPath("/img/Products/") + product.PicThumbnail);
                System.IO.File.Delete(Server.MapPath("/img/Products/262×393/") + product.PicThumbnail);
                System.IO.File.Delete(Server.MapPath("/img/Products/192×288/") + product.PicThumbnail);
                System.IO.File.Delete(Server.MapPath("/img/Products/1000×1500/") + product.PicThumbnail);
                System.IO.File.Delete(Server.MapPath("/img/Products/thum/") + product.PicThumbnail);
            }

            foreach (var item in db.ProductAttachFiles.Where(p => p.ProductID == id))
            {
                System.IO.File.Delete(Server.MapPath("/img/Products/AttachFiles/") + item.FileName);
                db.ProductAttachFiles.Remove(item);
            }
            foreach (var item in db.ProductCommentses.Where(p => p.ProductID == id))
            {
                db.ProductCommentses.Remove(item);
            }
            foreach (var item in db.ProductGalleries.Where(p => p.ProductID == id))
            {
                if (!item.Image.Contains("nopic.jpg"))
                {
                    System.IO.File.Delete(Server.MapPath("/img/Products/" + item.Image));
                    System.IO.File.Delete(Server.MapPath("/img/Products/1000×1500/" + item.Image));

                }
                db.ProductGalleries.Remove(item);
            }
            foreach (var item in db.ProductProperties.Where(p => p.ProductID == id))
            {
                db.ProductProperties.Remove(item);
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return true;
        }


        #endregion

        #region ProductProperty
        //Gallery Section
        public ActionResult Gallery(int id)
        {
            ViewBag.Galleries = db.ProductGalleries.Where(p => p.ProductID == id).ToList();
            ViewBag.productTitle = db.Products.Find(id).Title;

            return View(new ProductGallery()
            {
                ProductID = id
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gallery(ProductGallery productGallery, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null && imgUp.IsImage())
                {
                    productGallery.Image = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/img/Products/" + productGallery.Image));
                    ImageResizer img = new ImageResizer();

                    img.Resize(Server.MapPath("/img/Products/" + productGallery.Image),
                        Server.MapPath("/img/Products/1000×1500/" + productGallery.Image), 1000, 1500);

                    db.ProductGalleries.Add(productGallery);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Gallery", new { id = productGallery.ProductID });
        }
        public ActionResult DeleteGallery(int id)
        {
            var gallery = db.ProductGalleries.Find(id);
            if (!gallery.Image.Contains("nopic.jpg"))
            {
                System.IO.File.Delete(Server.MapPath("/img/Products/" + gallery.Image));
                System.IO.File.Delete(Server.MapPath("/img/Products/1000×1500/" + gallery.Image));

            }

            db.ProductGalleries.Remove(gallery);
            db.SaveChanges();
            return RedirectToAction("Gallery", new { id = gallery.ProductID });
        }


        //Product Attach File
        public ActionResult ProductAttachFile(int id)
        {
            ViewBag.ProductID = id;
            ViewBag.ProductName = db.Products.Find(id).Title;

            return View(db.ProductAttachFiles.Where(p => p.ProductID == id));
        }
        [HttpPost]
        public ActionResult ProductAttachFile(int ProductID, string FileTitle, HttpPostedFileBase Fileupl)
        {
            if (Fileupl != null && CheckContentdocument.isdocoment(Fileupl))
            {
                string filename = Guid.NewGuid() + Path.GetExtension(Fileupl.FileName);
                Fileupl.SaveAs(Server.MapPath("/img/Products/AttachFiles/") + filename);
                db.ProductAttachFiles.Add(new ProductAttachFile()
                {
                    AttachFileTitle = FileTitle,
                    FileName = filename,
                    ProductID = ProductID
                });
                db.SaveChanges();
            }
            else
            {
                ViewBag.errorpage = true;
            }
            ViewBag.ProductID = ProductID;
            ViewBag.ProductName = db.Products.Find(ProductID).Title;
            return View(db.ProductAttachFiles.Where(p => p.ProductID == ProductID));
        }
        public bool DeleteAttachFile(int id)
        {
            var item = db.ProductAttachFiles.Find(id);
            if (item != null)
            {
                System.IO.File.Delete(Server.MapPath("/img/Products/AttachFiles/") + item.FileName);
                db.ProductAttachFiles.Remove(item);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        //Product Property 
        public ActionResult ProductProperty(int id)
        {
            ViewBag.ProductID = id;
            ViewBag.ProductName = db.Products.Find(id).Title;
            return View(db.ProductProperties.Where(p => p.ProductID == id).ToList());

        }
        [HttpPost]
        public ActionResult ProductProperty(ProductProperty model)
        {
            db.ProductProperties.Add(model);
            db.SaveChanges();
            return Redirect("/Admin/Products/ProductProperty/" + model.ProductID);

        }
        public ActionResult DeleteProductProperty(int id)
        {
            var model = db.ProductProperties.Find(id);
            db.ProductProperties.Remove(model);
            db.SaveChanges();
            return Redirect("/Admin/Products/ProductProperty/" + model.ProductID);
        }
        #endregion

        #region ProductComment
        public ActionResult ProductCommentManage()
        {
            return View();
        }
        public ActionResult PostCommentResult(int pageId = 1)
        {
            ViewBag.pageId = pageId;
            var prodducts = db.ProductCommentses.OrderByDescending(p => p.CreateDate).ToList();

            int take = 10;
            int skip = (pageId - 1) * take;
            decimal pagecunt = Convert.ToDecimal(prodducts.Count()) / Convert.ToDecimal(take);
            ViewBag.PageCount = pagecunt;
            return PartialView(prodducts.Skip(skip).Take(take));
        }

        public ActionResult CommentEdite(int id)
        {
            ProductComments model = db.ProductCommentses.Find(id);
            if (model.ParentID != null)
            {
                ViewBag.parenttext = db.ProductCommentses.Find(model.ParentID).Comment;
            }
            return PartialView(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentEdite(ProductComments Model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductCommentManage");
            }
            return RedirectToAction("ProductCommentManage");
        }

        public bool PublishComment(int id)
        {
            var Post = db.ProductCommentses.Find(id);
            if (Post != null)
            {
                Post.Vaziaat = Vaziaat.Publish;
                db.ProductCommentses.AddOrUpdate(Post);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool DraftComment(int id)
        {
            var Post = db.ProductCommentses.Find(id);
            if (Post != null)
            {
                Post.Vaziaat = Vaziaat.UnReade;
                db.ProductCommentses.AddOrUpdate(Post);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool DeleteComment(int id)
        {
            var Post = db.ProductCommentses.Find(id);
            if (Post != null)
            {
                db.ProductCommentses.Remove(Post);
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
