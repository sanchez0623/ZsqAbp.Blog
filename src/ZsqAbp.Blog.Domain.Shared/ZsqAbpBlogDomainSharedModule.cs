using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ZsqAbp.Blog.Domain.Shared
{
    [DependsOn(typeof(AbpIdentityDomainSharedModule))]
    public class ZsqAbpBlogDomainSharedModule : AbpModule
    {
    }
}
