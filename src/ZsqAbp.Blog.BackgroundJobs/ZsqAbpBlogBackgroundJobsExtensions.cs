using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using ZsqAbp.Blog.BackgroundJobs.Jobs.Hangfire;

namespace ZsqAbp.Blog.BackgroundJobs
{
    public static class ZsqAbpBlogBackgroundJobsExtensions
    {
        public static void UseHangfireTest(this IServiceProvider service)
        {
            var job = service.GetService<HangfireTestJob>();

            RecurringJob.AddOrUpdate("定时任务测试", () => job.ExecuteAsync(), CronType.Minute());
        }
    }
}
