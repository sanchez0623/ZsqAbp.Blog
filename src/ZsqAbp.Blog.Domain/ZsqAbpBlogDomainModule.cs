using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using ZsqAbp.Blog.Domain.Shared;

namespace ZsqAbp.Blog.Domain
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(ZsqAbpBlogDomainSharedModule)
    )]
    public class ZsqAbpBlogDomainModule : AbpModule
    {
    }
}
