using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Partosazancnc.Models;
using Partosazancnc.Models.ViewModels;

namespace Partosazancnc.Controllers
{
    public class SearchController : Controller
    {
        MyContext db = new MyContext();
        // GET: Search
        public ActionResult Index(int pageid = 1, string Search = "")
        {
            List<SearchViewModel> list = new List<SearchViewModel>();
            foreach (var item in db.Products.Where(p =>(p.Title.Contains(Search) || p.ShortDiscription.Contains(Search) || p.Text.Contains(Search))&&p.Vaziaat==Vaziaat.Publish))
            {
                list.Add(new SearchViewModel()
                {
                    SearchTitle = item.Title,
                    DateTime = item.Date,
                    SearchURL = "Product/" + item.ProductID,
                    ShortDiscription = item.ShortDiscription
                });
            }
            foreach (var item in db.Posts.Where(p =>
                            (p.PostTitle.Contains(Search) || p.PostShortDiscription.Contains(Search) || p.PostText.Contains(Search))&& p.Vaziaat == Vaziaat.Publish))
            {
                list.Add(new SearchViewModel()
                {
                    SearchTitle = item.PostTitle,
                    DateTime = item.PostDate,
                    SearchURL = "Post/" + item.PostID,
                    ShortDiscription = item.PostShortDiscription
                });
            }
            foreach (var item in db.Pageses.Where(p =>
                                        (p.PageTitle.Contains(Search) || p.PageShortDiscription.Contains(Search) || p.PageContent.Contains(Search)) && p.Vaziaat == Vaziaat.Publish))
            {
                list.Add(new SearchViewModel()
                {
                    SearchTitle = item.PageTitle,
                    DateTime = DateTime.Now,
                    SearchURL = "page/" + item.PageID,
                    ShortDiscription = item.PageShortDiscription
                });
            }
            list = list.Distinct().ToList();
            ViewBag.pageid = pageid;
            int take = 10;
            int listcunt = list.Count;
            decimal pagecunt = Convert.ToDecimal(listcunt) / Convert.ToDecimal(take);
            int skip = (pageid - 1) / take;
            ViewBag.search = Search;
            ViewBag.pagecount = pagecunt;
            ViewBag.modelcunt = list.Count;
            return View(list.OrderByDescending(p => p.DateTime).Skip(skip).Take(take));
        }
    }
}