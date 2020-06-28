using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.DependencyInjection;

namespace ZsqAbp.Blog.Application.Caching
{
    public class CachingServiceBase : ITransientDependency
    {
        public IDistributedCache Cache { get; set; }
    }
}
