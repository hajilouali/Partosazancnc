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
    public class ProductTypesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Admin/ProductTypes
        public ActionResult Index()
        {
            return View(db.ProductTypes.ToList());
        }

       

        // GET: Admin/ProductTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductTypeId,Title,image,Discription")] ProductType productType,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                
                if (img !=null && CheckContentImage.IsImage(img))
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    productType.image = filename;
                    img.SaveAs(Server.MapPath("/img/Products/type/" + filename));
                    ImageResizer imgs = new ImageResizer();
                    imgs.Resize(Server.MapPath("/img/Products/type/" + filename),
                        Server.MapPath("/img/Products/type/thumline/" + filename), 150, 150);
                    imgs.Resize(Server.MapPath("/img/Products/type/" + filename),
                        Server.MapPath("/img/Products/type/265×176/" + filename), 265, 176);
                }
                else
                {
                    ModelState.AddModelError("image","لطفا تصویر شاخص را با فرمت های مجاز وارد نمایید.");
                    return View(productType);
                }
                db.ProductTypes.Add(productType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productType);
        }

        // GET: Admin/ProductTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // POST: Admin/ProductTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductTypeId,Title,image,Discription")] ProductType productType,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img !=null)
                {
                    if ( CheckContentImage.IsImage(img))
                    {
                        if (!productType.image.Contains("nopic"))
                        {
                            System.IO.File.Delete(Server.MapPath("/img/Products/type/"+ productType.image));
                            System.IO.File.Delete(Server.MapPath("/img/Products/type/thumline/" + productType.image));
                            System.IO.File.Delete(Server.MapPath("/img/Products/type/265×176/" + productType.image));
                        }
                        string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                        productType.image = filename;
                        img.SaveAs(Server.MapPath("/img/Products/type/" + filename));
                        ImageResizer imgs = new ImageResizer();
                        imgs.Resize(Server.MapPath("/img/Products/type/" + filename),
                            Server.MapPath("/img/Products/type/thumline/" + filename), 150, 150);
                        imgs.Resize(Server.MapPath("/img/Products/type/" + filename),
                            Server.MapPath("/img/Products/type/265×176/" + filename), 265, 176);
                    }
                    else
                    {
                        ModelState.AddModelError("image","لطفاْ تصویر خود را با فرمت مجاز وارد نمایید");
                        return View(productType);
                    }
                }
                db.Entry(productType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

       

        // POST: Admin/ProductTypes/Delete/5
        public bool DeleteConfirmed(int id)
        {
            ProductType productType = db.ProductTypes.Find(id);
            if (!productType.image.Contains("nopic"))
            {
                System.IO.File.Delete(Server.MapPath("/img/Products/type/" + productType.image));
                System.IO.File.Delete(Server.MapPath("/img/Products/type/thumline/" + productType.image));
                System.IO.File.Delete(Server.MapPath("/img/Products/type/265×176/" + productType.image));
            }

            foreach (var item in db.Products.Where(p=>p.ProductTypeId==id).ToList())
            {
                item.ProductTypeId = null;
                item.Vaziaat = Vaziaat.Draft;
                db.Products.AddOrUpdate(item);
            }
            db.ProductTypes.Remove(productType);
            db.SaveChanges();
            return true;
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
