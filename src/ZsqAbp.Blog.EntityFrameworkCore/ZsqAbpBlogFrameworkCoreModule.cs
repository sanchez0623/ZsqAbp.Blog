using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using ZsqAbp.Blog.Domain;
using ZsqAbp.Blog.Domain.Configurations;

namespace ZsqAbp.Blog.EntityFrameworkCore
{
    [DependsOn(
        typeof(ZsqAbpBlogDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpEntityFrameworkCorePostgreSqlModule),
        typeof(AbpEntityFrameworkCoreSqliteModule)
    )]
    public class ZsqAbpBlogFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ZsqAbpBlogDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                switch (AppSettings.EnableDb)
                {
                    case "SqlServer":
                        options.UseSqlServer();
                        break;
                    case "PostgreSql":
                        options.UseNpgsql();
                        //options.UsePostgreSql();
                        break;
                    case "Sqlite":
                        options.UseSqlite();
                        break;
                    case "MySQL":
                    default:
                        options.UseMySQL();
                        break;
                }
            });
        }
    }
}
