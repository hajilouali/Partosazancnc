using GSD.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DoormatSite.Tools;
using Partosazancnc.schedul;
using Partosazancnc.Tools;

namespace Partosazancnc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            JobScheduler.Start();
            JobSchedulerVisit.Start();
            //GlobalFilters.Filters.Add(new CompressAttribute());

        }
        void Session_Start(object sender, EventArgs e)
        {
            /////////////////////////////////////////////////
            Application.Lock();
            int result = Convert.ToInt32(xml.loadline("totalvistDay/coun"));
            result += 1;
            xml.SavetoXml("totalvistDay/coun", result.ToString());
            Application.UnLock();
            /////////////////////////////////////////////////
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var persianCulture = new PersianCulture();
            Thread.CurrentThread.CurrentCulture = persianCulture;
            Thread.CurrentThread.CurrentUICulture = persianCulture;
        }
        void Application_Error(object sender, EventArgs e)
        {
            if ((Server != null) &&
                (Server.GetLastError() != null) &&
                (Server.GetLastError().GetBaseException() != null))
            {
                System.Exception ex =
                    Server.GetLastError().GetBaseException();

                string strErrorMessage =
                    string.Format("{0} Time:{1:yyyy/MM/dd - hh:mm:ss},Path:{2},User IP{3}",
                        ex.Message,
                        System.DateTime.Now,
                        Request.PhysicalPath,
                        Request.UserHostAddress);

                Application.Lock();

                System.IO.StreamWriter oStreamWriter = null;

                try
                {
                    string strApplicationPath =
                        "~/App_Data/Log/Application.log";

                    string strApplicationPathName =
                        Server.MapPath(strApplicationPath);

                    oStreamWriter =
                        new System.IO.StreamWriter(strApplicationPathName, true, System.Text.Encoding.UTF8);

                    oStreamWriter.WriteLine(strErrorMessage);

                }
                catch
                {

                }

                finally
                {
                    if (oStreamWriter != null)
                    {
                        oStreamWriter.Dispose();
                        oStreamWriter = null;
                    }
                }

                Application.UnLock();
            }

        }
    }
}
