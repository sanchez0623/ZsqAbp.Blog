using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using ZsqAbp.Blog.Domain;

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
            base.ConfigureServices(context);
        }
    }
}
