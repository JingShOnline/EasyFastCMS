using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.BackgroundJobs;
using Hangfire;

namespace EasyFast.Common.Extend.Job
{
    public static class PeriodicJobExtensions
    {
        /// <summary>
        /// 周期任务扩展
        /// </summary>
        /// <typeparam name="TJob"></typeparam>
        /// <typeparam name="TArgs"></typeparam>
        /// <param name="jobManager"></param>
        /// <param name="args"></param>
        /// <param name="cron"></param>
        public static void AddOrUpdate<TJob, TArgs>(this IBackgroundJobManager jobManager, TArgs args, string cron = null) where TJob : IBackgroundJob<TArgs>

        {
            if (string.IsNullOrEmpty(cron))
                cron = PeriodicCorn.Daily(0);
            RecurringJob.AddOrUpdate<TJob>(job => job.Execute(args), cron, TimeZoneInfo.Local);
        }
    }
}
