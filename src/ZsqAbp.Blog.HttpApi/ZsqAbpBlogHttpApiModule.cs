using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using ZsqAbp.Blog.Application;

namespace ZsqAbp.Blog.HttpApi
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(ZsqAbpBlogApplicationModule)
    )]
    public class ZsqAbpBlogHttpApiModule : AbpModule
    {
    }
}
