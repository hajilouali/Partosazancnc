using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Partosazancnc.Models;
using Partosazancnc.Models.ViewModels;
using Menu = Partosazancnc.Models.Menu;

namespace Partosazancnc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MenuController : Controller
    {
        MyContext db=new MyContext();
        // GET: Admin/Menu
        public ActionResult Index()
        {

            List<MenuItemViewModel> item = new List<MenuItemViewModel>();
            item.Add(new MenuItemViewModel()
            {
                Title = "خانه ",
                URL = "/"
            });
            item.Add(new MenuItemViewModel()
            {
                Title = "تماس با ما",
                URL = "/ContactUs/"
            });
            item.Add(new MenuItemViewModel()
            {
                Title = "مقالات",
                URL = "/PostArchive"
            });
            item.Add(new MenuItemViewModel()
            {
                Title = "محصولات ما",
                URL = "/ProductArchive"
            });
            foreach (var VARIABLE in db.ProductTypes.ToList())
            {
                item.Add(new MenuItemViewModel()
                {
                    Title = VARIABLE.Title,
                    URL = "/ProductArchive?ProductCategory=" + VARIABLE.ProductTypeId
                });
            }
            foreach (var VARIABLE in db.Products.ToList())
            {
                item.Add(new MenuItemViewModel()
                {
                    Title = VARIABLE.Title,
                    URL = "/Product/" + VARIABLE.ProductID
                });
            }

            foreach (var VARIABLE in db.Posts.ToList())
            {
                item.Add(new MenuItemViewModel()
                {
                    Title = VARIABLE.PostTitle,
                    URL = "/Post/" + VARIABLE.PostID
                });
            }
            foreach (var i in db.Pageses.ToList())
            {

                item.Add(new MenuItemViewModel()
                {
                    Title = i.PageTitle,
                    URL = "/page/" + i.PageID
                });
            }

            ViewBag.item = item;
            List<Menu> listmenu = new List<Menu>();

            foreach (var VARIABLE in db.Menus.ToList())
            {
                if (VARIABLE.ParentID == 0)
                {
                    listmenu.Add(VARIABLE);
                }

            }
            ViewBag.parents = listmenu;

            return View(db.Menus.ToList());
        }

        public bool addmenu( string title, string url, int parentid)
        {

            try
            {
                db.Menus.Add(new Models.Menu()
                {
                   MenuTitle = title,
                   ParentID = parentid,
                   URL = url
                });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deletrowmenu(int id)
        {
            try
            {
                foreach (var VARIABLE in db.Menus.Where(p => p.ParentID == id))
                {
                    db.Menus.Remove(VARIABLE);
                }
                db.Menus.Remove(db.Menus.Find(id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

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