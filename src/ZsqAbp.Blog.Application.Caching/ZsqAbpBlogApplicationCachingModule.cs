using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using ZsqAbp.Blog.Domain;
using ZsqAbp.Blog.Domain.Configurations;

namespace ZsqAbp.Blog.Application.Caching
{
    [DependsOn(
       typeof(AbpCachingModule),
       typeof(ZsqAbpBlogDomainModule)
    )]
    public class ZsqAbpBlogApplicationCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = AppSettings.Caching.RedisConnectionString;
                //实例名
                //options.InstanceName
                //配置属性
                //options.ConfigurationOptions
            });
        }
    }
}
