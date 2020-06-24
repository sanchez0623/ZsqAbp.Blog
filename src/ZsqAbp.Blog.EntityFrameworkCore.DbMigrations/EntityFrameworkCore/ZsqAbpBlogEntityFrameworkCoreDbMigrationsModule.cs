using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ZsqAbp.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    [DependsOn(
        typeof(ZsqAbpBlogFrameworkCoreModule)
    )]
    public class ZsqAbpBlogEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ZsqAbpBlogMigrationsDbContext>();
        }
    }
}
