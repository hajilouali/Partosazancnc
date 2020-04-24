using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DoormatSite.Tools;
using Partosazancnc.Models;
using Partosazancnc.Models.ViewModels;
using Quartz;
using Tools;

namespace Partosazancnc.schedul
{

    public class NewsLetter : IJob
    {
        MyContext db = new MyContext();
        public async Task Execute(IJobExecutionContext context)
        {
            if (DateTime.Now.ToString("dd") == "01")
            {
                foreach (var VARIABLE in db.NewsLetterses.Where(p => p.Days.ToLower().Contains("monthly") && p.DateTime.Hour == DateTime.Now.Hour && p.IsActive == true).ToList())
                {
                    foreach (var item in db.NewsLetterMembers.Where(a => a.NewsLetterListId == VARIABLE.NewsLetterListId))
                    {
                        var user = db.NewsLettersMails.Find(item.NewsLettersMailID);
                        string to = user.Email;
                        string sub = "خبرنامه  " + "-" + xml.loadline("siteSetting/siteName");
                        string body = PartialToStringClass.urltostring(ConfigurationManager.AppSettings["MyDomain"]+"/ManageEmails/NewsLetter?activecode=" + user.DeActivatCode + "&bodyid=" + VARIABLE.NewsLetterId);
                        SendEmail.Send(to, sub, body);
                    }
                }
            }

            foreach (var VARIABLE in db.NewsLetterses.Where(p => p.Days.ToLower().Contains("dayly") && p.IsActive == true).ToList())
            {
                if (VARIABLE.DateTime.ToString("HH").Contains(DateTime.Now.ToString("HH")))
                {
                    foreach (var item in db.NewsLetterMembers.Where(a => a.NewsLetterListId == VARIABLE.NewsLetterListId))
                    {

                        var user = db.NewsLettersMails.Find(item.NewsLettersMailID);
                        string to = user.Email;
                        string sub = "خبرنامه  " + "-" + xml.loadline("siteSetting/siteName");
                        string body = PartialToStringClass.urltostring(ConfigurationManager.AppSettings["MyDomain"]+"/ManageEmails/NewsLetter?activecode=" + user.DeActivatCode + "&bodyid=" + VARIABLE.NewsLetterId);

                        SendEmail.Send(to, sub, body);



                    }
                }

            }
            foreach (var VARIABLE in db.NewsLetterses.Where(p => p.IsActive == true))
            {
                if (VARIABLE.DateTime.ToString("HH").Contains(DateTime.Now.ToString("HH")) && VARIABLE.Days.ToLower().Contains(DateTime.Now.ToString("ddddd").ToLower()))
                {
                    foreach (var item in db.NewsLetterMembers.Where(a => a.NewsLetterListId == VARIABLE.NewsLetterListId))
                    {
                        var user = db.NewsLettersMails.Find(item.NewsLettersMailID);
                        string to = user.Email;
                        string sub = "خبرنامه  " + "-" + xml.loadline("siteSetting/siteName");
                        string body = PartialToStringClass.urltostring(ConfigurationManager.AppSettings["MyDomain"] + "/ManageEmails/NewsLetter?activecode=" + user.DeActivatCode + "&bodyid=" + VARIABLE.NewsLetterId);

                        SendEmail.Send(to, sub, body);
                    }
                }

            }
            db.Dispose();
        }
    }
}