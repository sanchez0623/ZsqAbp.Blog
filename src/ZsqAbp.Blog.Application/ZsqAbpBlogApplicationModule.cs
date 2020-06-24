using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ZsqAbp.Blog.Application
{
    [DependsOn(
       typeof(AbpIdentityApplicationModule)
    )]
    public class ZsqAbpBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}
