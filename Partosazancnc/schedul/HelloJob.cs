using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Quartz;

namespace Partosazancnc.schedul
{
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("/App_Data/Log.txt");

            using (StreamWriter sw = new StreamWriter(path, true))
            {
               sw.WriteLine("Message from HelloJob " + DateTime.Now.ToString());
            }
        }
    }
}