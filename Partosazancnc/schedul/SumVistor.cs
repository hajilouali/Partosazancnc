using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Quartz;
using System.Web.UI;
using System.Web.UI.WebControls;
using DoormatSite.Tools;
using Partosazancnc.Models;

namespace Partosazancnc.schedul
{
    public class SumVistor:IJob
    {
        MyContext db = new MyContext();
        public async Task Execute(IJobExecutionContext context)
        {
            int count = Convert.ToInt32(xml.loadline("totalvistDay/coun"));
            db.VisitorLogses.Add(new VisitorLogs()
            {
                DateTime = DateTime.Now,
                VisitCount = count,

            });
            db.SaveChanges();
            db.Dispose();
            xml.SavetoXml("totalvistDay/coun", "0");
        }
    }
}