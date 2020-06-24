using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ZsqAbp.Blog.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class ZsqAbpBlogDomainModule : AbpModule
    {
    }
}
