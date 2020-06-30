using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using ZsqAbp.Blog.Application.Caching;

namespace ZsqAbp.Blog.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(ZsqAbpBlogApplicationCachingModule),
        typeof(AbpAutoMapperModule)
    )]
    public class ZsqAbpBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ZsqAbpBlogApplicationModule>(validate: true);
                options.AddProfile<ZsqAbpBlogAutoMapperProfile>(validate: true);
            });
        }
    }
}
