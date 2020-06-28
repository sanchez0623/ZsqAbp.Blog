using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using ZsqAbp.Blog.Application.Caching;

namespace ZsqAbp.Blog.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(ZsqAbpBlogApplicationCachingModule)
    )]
    public class ZsqAbpBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
