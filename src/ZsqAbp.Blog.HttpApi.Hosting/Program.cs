﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using ZsqAbp.Blog.ToolKits.Extensions;

namespace ZsqAbp.Blog.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseLog4Net()
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.UseIISIntegration()
                           .UseStartup<Startup>();
                })
                .UseAutofac()
                .Build()
                .RunAsync();
        }
    }
}
