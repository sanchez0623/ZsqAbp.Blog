using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ZsqAbp.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class ZsqAbpBlogMigrationsDbContextFactory : IDesignTimeDbContextFactory<ZsqAbpBlogMigrationsDbContext>
    {
        public ZsqAbpBlogMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ZsqAbpBlogMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new ZsqAbpBlogMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
