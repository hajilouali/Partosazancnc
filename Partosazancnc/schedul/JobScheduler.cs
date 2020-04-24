using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace Partosazancnc.schedul
{
    public class JobScheduler
    {
        public async static void Start()
        {
            IJobDetail job = JobBuilder.Create<NewsLetter>()
                .WithIdentity("job1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .ForJob(job)
                .WithIdentity("trigger1")
                .StartNow()
                .WithCronSchedule("	0 0/59 * 1/1 * ? *")
                .Build();

            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sc =await sf.GetScheduler();
            sc.ScheduleJob(job, trigger);

            sc.Start();
        }
    }
    public class JobSchedulerVisit
    {
        public async static void Start()
        {
            IJobDetail job = JobBuilder.Create<SumVistor>()
                .WithIdentity("job2")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .ForJob(job)
                .WithIdentity("trigger2")
                .StartNow()
                .WithCronSchedule("0 59 23 * * ?")
                .Build();

            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler scc = await sf.GetScheduler();
            scc.ScheduleJob(job, trigger);

            scc.Start();
        }
    }
}