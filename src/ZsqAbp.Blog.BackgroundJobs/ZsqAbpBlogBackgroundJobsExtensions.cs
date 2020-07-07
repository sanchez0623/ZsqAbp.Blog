using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using ZsqAbp.Blog.BackgroundJobs.Jobs.Wallpaper;

namespace ZsqAbp.Blog.BackgroundJobs
{
    public static class ZsqAbpBlogBackgroundJobsExtensions
    {
        /// <summary>
        /// 壁纸数据抓取
        /// </summary>
        /// <param name="service"></param>
        public static void UseWallpaperJob(this IServiceProvider service)
        {
            var job = service.GetService<WallpaperJob>();

            RecurringJob.AddOrUpdate("壁纸数据抓取", () => job.ExecuteAsync(), CronType.Hour(1, 3));
        }
    }
}
