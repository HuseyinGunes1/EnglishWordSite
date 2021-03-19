using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_BussinesLayer
{
  public  class QuartzTriger
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<QuartzJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
               
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(17, 47))
                .Build();

            scheduler.ScheduleJob(job, trigger);

           

        }

        public static void Start2()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<QuartzJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()

                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(17, 48))
                .Build();

            scheduler.ScheduleJob(job, trigger);



        }
    }
}
