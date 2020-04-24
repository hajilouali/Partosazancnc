using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models.ViewModels;
using DoormatSite.Tools;
using Partosazancnc.Models;
using Tools;

namespace Partosazancnc.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        MyContext db = new MyContext();
        // GET: Admin/Home


        private string[] liStrings =
            System.IO.File.ReadAllLines(
                System.Web.HttpContext.Current.Server.MapPath("/App_Data/PageContent/Slider/data-transition.txt"));
        List<SelectListItem> data_transition = new List<SelectListItem>();
        List<SelectListItem> data_slotamount = new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "",
                Value = ""
            },
            new SelectListItem()
            {
                Text = "1",
                Value = "1"
            },
            new SelectListItem
            {
                Text = "2",
                Value = "2",

            },
            new SelectListItem
            {
                Text = "3",
                Value = "3"
            }
,
            new SelectListItem
            {
                Text = "4",
                Value = "4"
            }
,
            new SelectListItem
            {
                Text = "5",
                Value = "5"
            }
,
            new SelectListItem
            {
                Text = "6",
                Value = "6"
            }
,
            new SelectListItem
            {
                Text = "7",
                Value = "7"
            }
,
            new SelectListItem
            {
                Text = "8",
                Value = "8"
            }
,
            new SelectListItem
            {
                Text = "9",
                Value = "9"
            }
,
            new SelectListItem
            {
                Text = "10",
                Value = "10"
            }

        };
        List<SelectListItem> data_masterspeed = new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "",
                Value = ""
            },
            new SelectListItem()
            {
                Text = "100",
                Value = "100"
            },
            new SelectListItem
            {
                Text = "200",
                Value = "200",

            },
            new SelectListItem
            {
                Text = "300",
                Value = "300"
            }
            ,
            new SelectListItem
            {
                Text = "400",
                Value = "400"
            }
            ,
            new SelectListItem
            {
                Text = "500",
                Value = "500"
            }
            ,
            new SelectListItem
            {
                Text = "600",
                Value = "600"
            }
            ,
            new SelectListItem
            {
                Text = "700",
                Value = "700"
            }
            ,
            new SelectListItem
            {
                Text = "800",
                Value = "800"
            }
            ,
            new SelectListItem
            {
                Text = "900",
                Value = "900"
            }
            ,
            new SelectListItem
            {
                Text = "1000",
                Value = "1000"
            }
        };
        List<SelectListItem> data_Delay = new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "",
                Value = ""
            },
            new SelectListItem()
            {
                Text = "100",
                Value = "100"
            },
            new SelectListItem
            {
                Text = "200",
                Value = "200",

            },
            new SelectListItem
            {
                Text = "300",
                Value = "300"
            }
            ,
            new SelectListItem
            {
                Text = "400",
                Value = "400"
            }
            ,
            new SelectListItem
            {
                Text = "500",
                Value = "500"
            }
            ,
            new SelectListItem
            {
                Text = "600",
                Value = "600"
            }
            ,
            new SelectListItem
            {
                Text = "700",
                Value = "700"
            }
            ,
            new SelectListItem
            {
                Text = "800",
                Value = "800"
            }
            ,
            new SelectListItem
            {
                Text = "900",
                Value = "900"
            }
            ,
            new SelectListItem
            {
                Text = "1000",
                Value = "1000"
            }
        };
        List<SelectListItem> data_saveperformance = new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "On",
                Value = "On"
            },
            new SelectListItem
            {
                Text = "Off",
                Value = "Off",
                Selected = true

            },

        };
        List<SelectListItem> Imagedatabgposition = new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "left top",
                Value = "left top"
            },
            new SelectListItem
            {
                Text = "left center",
                Value = "left center",


            },
            new SelectListItem
            {
                Text = "left right",
                Value = "left right"
            },
            new SelectListItem()
            {
                Text = "center top",
                Value = "center top"
            },
            new SelectListItem
            {
                Text = "center center",
                Value = "center center",


            },
            new SelectListItem
            {
                Text = "center right",
                Value = "center right"
            },
            new SelectListItem()
            {
                Text = "bottom top",
                Value = "bottom top"
            },
            new SelectListItem
            {
                Text = "bottom center",
                Value = "bottom center",


            },
            new SelectListItem
            {
                Text = "bottom right",
                Value = "bottom right"
            }
        };
        List<SelectListItem> Imagedatabgfit = new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "auto",
                Value = "auto"
            },
            new SelectListItem
            {
                Text = "length",
                Value = "length"


            },
            new SelectListItem
            {
                Text = "cover",
                Value = "cover"
            },
            new SelectListItem
            {
                Text = "contain",
                Value = "contain"
            }
        };

        private string[] data_easinglist =
            System.IO.File.ReadAllLines(
                System.Web.HttpContext.Current.Server.MapPath("/App_Data/PageContent/Slider/data-easing.txt"));
        List<SelectListItem> data_easing = new List<SelectListItem>();
        List<SelectListItem> data_splitin = new List<SelectListItem>(){
            new SelectListItem()
            {
                Text = "انتخاب کنید",
                Value = ""
            },
            new SelectListItem
            {
                Text = "none",
                Value = "none"


            },
        };
        List<SelectListItem> data_splitout = new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "انتخاب کنید",
                Value = ""
            },
            new SelectListItem
            {
                Text = "none",
                Value = "none"


            },
        };
        List<SelectListItem> data_captionhidden = new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "انتخاب کنید",
                Value = ""
            },
            new SelectListItem
            {
                Text = "ON",
                Value = "on"


            },new SelectListItem
            {
                Text = "off",
                Value = "off"


            },
        };
        public ActionResult Index()
        {
            ViewBag.repost = db.PostCommentses.Where(p => p.Vaziaat != Vaziaat.Publish).Count() +
                             db.ProductCommentses.Where(p => p.Vaziaat != Vaziaat.Publish).Count() +
                             db.UserFaqses.Where(p => p.Vaziaat != Vaziaat.Reade).Count() +
                             db.ContactUsMessages.Where(p => p.Vaziaat != Vaziaat.Reade).Count()
                ;
            ViewBag.PoctCount = db.Posts.Where(ps => ps.Vaziaat == Vaziaat.Publish).Count();
            ViewBag.products = db.Products.Where(ps => ps.Vaziaat == Vaziaat.Publish).Count();
            VisiteViewModel listmodel = new VisiteViewModel();
            string car = Convert.ToString("'");
            foreach (var VARIABLE in db.VisitorLogses.OrderBy(s => s.DateTime).Where(p => p.DateTime.Year == DateTime.Now.Year && p.DateTime.Month == DateTime.Now.Month))
            {

                listmodel.Count += string.Format(VARIABLE.VisitCount + ",");
                listmodel.daynale += string.Format(car + VARIABLE.DateTime.ToString("dd MMMM") + car + ',');


            }

            listmodel.Count += Convert.ToString(xml.loadline("totalvistDay/coun")+',');
            listmodel.daynale += Convert.ToString(car + DateTime.Now.ToString("dd MMMM")+ car + ',');
            
            ViewBag.listmodel = listmodel;
            return View();
        }

        public ActionResult siderBar()
        {
            ViewBag.CommetPost = db.PostCommentses.Where(p => p.Vaziaat != Vaziaat.Publish).Count();
            ViewBag.productPost = db.ProductCommentses.Where(p => p.Vaziaat != Vaziaat.Publish).Count();
            ViewBag.userfaq = db.UserFaqses.Where(p => p.Vaziaat != Vaziaat.Reade).Count();
            ViewBag.contactus = db.ContactUsMessages.Where(p => p.Vaziaat != Vaziaat.Reade).Count();
            return PartialView();
        }

        #region SiteSetting
        public ActionResult siteSetting()
        {
            return View();
        }

        public ActionResult overview()
        {
            OverviewViewModel model = new OverviewViewModel()
            {
                Logo = xml.loadline("siteSetting/logo"),
                fivicon = xml.loadline("siteSetting/fivicon"),
                SiteDiscription = xml.loadline("siteSetting/siteDiscription"),
                SiteKeyWord = xml.loadline("siteSetting/sitekeywords"),
                SiteName = xml.loadline("siteSetting/siteName")
            };
            return PartialView(model);
        }

        public ActionResult overviewsave(OverviewViewModel Model, HttpPostedFileBase logo, HttpPostedFileBase fivicon)
        {
            if (ModelState.IsValid)
            {
                xml.SavetoXml("siteSetting/siteDiscription", Model.SiteDiscription);
                xml.SavetoXml("siteSetting/siteName", Model.SiteName);
                xml.SavetoXml("siteSetting/sitekeywords", Model.SiteKeyWord);
                if (logo != null && CheckContentImage.IsImage(logo))
                {
                    if (!string.IsNullOrEmpty(xml.loadline("siteSetting/logo")))
                    {
                        System.IO.File.Delete(Server.MapPath("/img/") + xml.loadline("siteSetting/logo"));
                    }

                    string filename = Guid.NewGuid() + Path.GetExtension(logo.FileName);
                    xml.SavetoXml("siteSetting/logo", filename);
                    logo.SaveAs(Server.MapPath("/img/") + filename);

                }
                if (fivicon != null && CheckContentImage.IsImage(fivicon))
                {
                    if (!string.IsNullOrEmpty(xml.loadline("siteSetting/fivicon")))
                    {
                        System.IO.File.Delete(Server.MapPath("/img/") + xml.loadline("siteSetting/fivicon"));
                    }

                    string filename = Guid.NewGuid() + Path.GetExtension(fivicon.FileName);
                    xml.SavetoXml("siteSetting/fivicon", filename);
                    fivicon.SaveAs(Server.MapPath("/img/") + filename);
                }

                ViewBag.succrssm = true;
                return Redirect("/Admin/Home/siteSetting");
            }

            return RedirectToAction("siteSetting");
        }

        public ActionResult social()
        {
            return PartialView(new socialViewModel()
            {
                Instagram = xml.loadline("contact/Instagram"),
                FaceBook = xml.loadline("contact/FaceBook"),
                Aparat = xml.loadline("contact/Aparat"),
                Telegram = xml.loadline("contact/Telegram")
            });
        }

        public bool socialsave(socialViewModel model)
        {
            if (ModelState.IsValid)
            {

                xml.SavetoXml("contact/Instagram", model.Instagram);
                xml.SavetoXml("contact/FaceBook", model.FaceBook);
                xml.SavetoXml("contact/Aparat", model.Aparat);
                xml.SavetoXml("contact/Telegram", model.Telegram);
                return true;
            }
            return false;
        }

        public ActionResult contactus()
        {
            return PartialView(new ContactUsViewModel()
            {
                Address = xml.loadline("contact/address"),
                EmailWebsite = xml.loadline("contact/email"),
                Phone = xml.loadline("contact/Phone")
            });
        }
        [ValidateAntiForgeryToken]
        public bool contactussave(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                xml.SavetoXml("contact/address", model.Address);
                xml.SavetoXml("contact/email", model.EmailWebsite);
                xml.SavetoXml("contact/Phone", model.Phone);
                return true;
            }

            return false;
        }

        public ActionResult EmailSetting()
        {
            return PartialView(new EmailSettingViewModel()
            {
                EmailHost = xml.loadline("EmailSetting/EmailHost"),
                EmailUserName = xml.loadline("EmailSetting/EmailUserName"),
                EmailPort = Convert.ToInt32(xml.loadline("EmailSetting/EmailPort")),
                EmailPassword = xml.loadline("EmailSetting/EmailPassword")

            });
        }
        [ValidateAntiForgeryToken]
        public bool Emailsettingsave(EmailSettingViewModel model)
        {
            if (ModelState.IsValid)
            {
                xml.SavetoXml("EmailSetting/EmailHost", model.EmailHost);
                xml.SavetoXml("EmailSetting/EmailUserName", model.EmailUserName);
                xml.SavetoXml("EmailSetting/EmailPort", model.EmailPort.ToString());
                xml.SavetoXml("EmailSetting/EmailPassword", model.EmailPassword);
                return true;
            }
            return false;
        }


        #endregion
        #region SliderManagment

        public ActionResult Sliders()
        {
            return View(db.Sliderses.ToList());
        }
        public ActionResult CreateSlider()
        {
            foreach (var VARIABLE in liStrings)
            {
                data_transition.Add(new SelectListItem()
                {
                    Text = VARIABLE,
                    Value = VARIABLE
                });
            }
            ViewBag.data_transition = new SelectList(data_transition, "Value", "Text");
            ViewBag.data_slotamount = new SelectList(data_slotamount, "Value", "Text");
            ViewBag.data_masterspeed = new SelectList(data_masterspeed, "Value", "Text");
            ViewBag.data_Delay = new SelectList(data_Delay, "Value", "Text");
            ViewBag.data_saveperformance = new SelectList(data_saveperformance, "Value", "Text");
            ViewBag.Imagedatabgposition = new SelectList(Imagedatabgposition, "Value", "Text");
            ViewBag.Imagedatabgfit = new SelectList(Imagedatabgfit, "Value", "Text");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSlider(Sliders model, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (CheckContentImage.IsImage(img) && img != null)
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/") + filename);
                    model.ImageSlider = "/img/" + filename;
                    db.Sliderses.Add(model);
                    db.SaveChanges();
                    return Redirect("/Admin/Home/Sliders");
                }
                ModelState.AddModelError("ImageSlider", "لطفا تصویر خود را با فرمت مجاز ارسال فرمایید");
            }
            foreach (var VARIABLE in liStrings)
            {
                data_transition.Add(new SelectListItem()
                {
                    Text = VARIABLE,
                    Value = VARIABLE
                });
            }
            ViewBag.data_transition = new SelectList(data_transition, "Value", "Text");
            ViewBag.data_slotamount = new SelectList(data_slotamount, "Value", "Text");
            ViewBag.data_masterspeed = new SelectList(data_masterspeed, "Value", "Text");
            ViewBag.data_Delay = new SelectList(data_Delay, "Value", "Text");
            ViewBag.data_saveperformance = new SelectList(data_saveperformance, "Value", "Text");
            ViewBag.Imagedatabgposition = new SelectList(Imagedatabgposition, "Value", "Text");
            ViewBag.Imagedatabgfit = new SelectList(Imagedatabgfit, "Value", "Text");
            return View(model);
        }

        public ActionResult EditeSlider(int id)
        {
            var model = db.Sliderses.Find(id);
            foreach (var VARIABLE in liStrings)
            {
                data_transition.Add(new SelectListItem()
                {
                    Text = VARIABLE,
                    Value = VARIABLE
                });
            }
            ViewBag.data_transition = new SelectList(data_transition, "Value", "Text", model.data_transition);
            ViewBag.data_slotamount = new SelectList(data_slotamount, "Value", "Text", model.data_slotamount);
            ViewBag.data_masterspeed = new SelectList(data_masterspeed, "Value", "Text", model.data_masterspeed);
            ViewBag.data_Delay = new SelectList(data_Delay, "Value", "Text", model.data_Delay);
            ViewBag.data_saveperformance = new SelectList(data_saveperformance, "Value", "Text", model.data_saveperformance);
            ViewBag.Imagedatabgposition = new SelectList(Imagedatabgposition, "Value", "Text", model.Imagedatabgposition);
            ViewBag.Imagedatabgfit = new SelectList(Imagedatabgfit, "Value", "Text", model.Imagedatabgfit);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditeSlider(Sliders model, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && CheckContentImage.IsImage(img))
                {
                    System.IO.File.Delete(Server.MapPath(model.ImageSlider));
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/") + filename);
                    model.ImageSlider = "/img/" + filename;
                }

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Admin/Home/Sliders");

            }
            foreach (var VARIABLE in liStrings)
            {
                data_transition.Add(new SelectListItem()
                {
                    Text = VARIABLE,
                    Value = VARIABLE
                });
            }
            ViewBag.data_transition = new SelectList(data_transition, "Value", "Text", model.data_transition);
            ViewBag.data_slotamount = new SelectList(data_slotamount, "Value", "Text", model.data_slotamount);
            ViewBag.data_masterspeed = new SelectList(data_masterspeed, "Value", "Text", model.data_masterspeed);
            ViewBag.data_Delay = new SelectList(data_Delay, "Value", "Text", model.data_Delay);
            ViewBag.data_saveperformance = new SelectList(data_saveperformance, "Value", "Text", model.data_saveperformance);
            ViewBag.Imagedatabgposition = new SelectList(Imagedatabgposition, "Value", "Text", model.Imagedatabgposition);
            ViewBag.Imagedatabgfit = new SelectList(Imagedatabgfit, "Value", "Text", model.Imagedatabgfit);
            return View(model);
        }

        public ActionResult LayerSlider(int id)
        {
            ViewBag.SliderId = id;
            return View(db.LayerSliderses.Where(p => p.SlideID == id).ToList());
        }

        public ActionResult SliResult(int id)
        {
            return PartialView(db.Sliderses.Find(id));
        }

        public ActionResult LayResult(int id)
        {
            ViewBag.Slideid = id;
            return PartialView(db.LayerSliderses.Where(p => p.SlideID == id).ToList());
        }

        public ActionResult AddLayerToSlider(int id)
        {
            foreach (var VARIABLE in data_easinglist)
            {
                data_easing.Add(new SelectListItem()
                {
                    Text = VARIABLE,
                    Value = VARIABLE
                });
            }
            ViewBag.data_easing = new SelectList(data_easing, "Value", "Text");
            ViewBag.data_splitin = new SelectList(data_splitin, "Value", "Text");
            ViewBag.data_splitout = new SelectList(data_splitout, "Value", "Text");
            ViewBag.data_captionhidden = new SelectList(data_captionhidden, "Value", "Text");
            ViewBag.data_endeasing = new SelectList(data_easing, "Value", "Text");
            return View(new LayerSliders()
            {
                SlideID = id
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLayerToSlider(LayerSliders model, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && CheckContentImage.IsImage(img))
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/") + filename);
                    model.LayerImage = "/img/" + filename;
                }

                db.LayerSliderses.Add(model);
                db.SaveChanges();
                return Redirect("/Admin/Home/LayerSlider/" + model.SlideID);
            }
            foreach (var VARIABLE in data_easinglist)
            {
                data_easing.Add(new SelectListItem()
                {
                    Text = VARIABLE,
                    Value = VARIABLE
                });
            }
            ViewBag.data_easing = new SelectList(data_easing, "Value", "Text");
            ViewBag.data_splitin = new SelectList(data_splitin, "Value", "Text");
            ViewBag.data_splitout = new SelectList(data_splitout, "Value", "Text");
            ViewBag.data_captionhidden = new SelectList(data_captionhidden, "Value", "Text");
            ViewBag.data_endeasing = new SelectList(data_easing, "Value", "Text");
            return View(model);
        }
        public ActionResult EditLayerToSlider(int id)
        {
            LayerSliders model = db.LayerSliderses.Find(id);
            foreach (var VARIABLE in data_easinglist)
            {
                data_easing.Add(new SelectListItem()
                {
                    Text = VARIABLE,
                    Value = VARIABLE
                });
            }
            ViewBag.data_easing = new SelectList(data_easing, "Value", "Text", model.data_easing);
            ViewBag.data_splitin = new SelectList(data_splitin, "Value", "Text", model.data_splitin);
            ViewBag.data_splitout = new SelectList(data_splitout, "Value", "Text", model.data_splitout);
            ViewBag.data_captionhidden = new SelectList(data_captionhidden, "Value", "Text", model.data_captionhidden);
            ViewBag.data_endeasing = new SelectList(data_easing, "Value", "Text", model.data_easing);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLayerToSlider(LayerSliders model, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && CheckContentImage.IsImage(img))
                {
                    if (!string.IsNullOrEmpty(model.LayerImage))
                    {
                        System.IO.File.Delete(Server.MapPath(model.LayerImage));
                    }
                    string filename = Guid.NewGuid() + Path.GetExtension(img.FileName);
                    img.SaveAs(Server.MapPath("/img/") + filename);
                    model.LayerImage = "/img/" + filename;
                    model.LayerText = null;
                }

                if (!string.IsNullOrEmpty(model.LayerText))
                {
                    if (!string.IsNullOrEmpty(model.LayerImage))
                    {
                        System.IO.File.Delete(Server.MapPath(model.LayerImage));
                    }
                    model.LayerImage = null;

                }

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/Admin/Home/LayerSlider/" + model.SlideID);
            }
            foreach (var VARIABLE in data_easinglist)
            {
                data_easing.Add(new SelectListItem()
                {
                    Text = VARIABLE,
                    Value = VARIABLE
                });
            }
            ViewBag.data_easing = new SelectList(data_easing, "Value", "Text", model.data_easing);
            ViewBag.data_splitin = new SelectList(data_splitin, "Value", "Text", model.data_splitin);
            ViewBag.data_splitout = new SelectList(data_splitout, "Value", "Text", model.data_splitout);
            ViewBag.data_captionhidden = new SelectList(data_captionhidden, "Value", "Text", model.data_captionhidden);
            ViewBag.data_endeasing = new SelectList(data_easing, "Value", "Text", model.data_easing);
            return View(model);
        }

        public bool DeleteLayer(int id)
        {
            LayerSliders model = db.LayerSliderses.Find(id);
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.LayerImage))
                {
                    System.IO.File.Delete(Server.MapPath(model.LayerImage));
                }

                db.LayerSliderses.Remove(model);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteSlider(int id)
        {
            Models.Sliders model = db.Sliderses.Find(id);
            if (model != null)
            {
                foreach (var item in db.LayerSliderses.Where(p => p.SlideID == id))
                {
                    if (!string.IsNullOrEmpty(item.LayerImage))
                    {
                        System.IO.File.Delete(Server.MapPath(item.LayerImage));
                    }

                    db.LayerSliderses.Remove(item);
                }

                db.Sliderses.Remove(model);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region CatalogSetting

        public ActionResult CatalogSetting()
        {
            ViewBag.catalog = xml.loadline("siteSetting/Catalog");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CatalogSetting(HttpPostedFileBase upl)
        {
            if (ModelState.IsValid)
            {
                if (upl != null && CheckContentdocument.isdocoment(upl))
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(upl.FileName);
                    upl.SaveAs(Server.MapPath("/img/") + filename);
                    xml.SavetoXml("siteSetting/Catalog", "/img/" + filename);
                    ViewBag.Erorr = false;
                }
                else
                {
                    ViewBag.Erorr = true;
                }
            }

            ViewBag.catalog = xml.loadline("siteSetting/Catalog");
            return View();
        }

        public bool deletcatalog()
        {
            System.IO.File.Delete(Server.MapPath(xml.loadline("siteSetting/Catalog")));
            xml.SavetoXml("siteSetting/Catalog", "");
            return true;
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