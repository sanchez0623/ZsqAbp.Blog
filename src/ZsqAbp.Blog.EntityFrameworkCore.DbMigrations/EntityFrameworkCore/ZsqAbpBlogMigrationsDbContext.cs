using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ZsqAbp.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class ZsqAbpBlogMigrationsDbContext : AbpDbContext<ZsqAbpBlogMigrationsDbContext>
    {
        public ZsqAbpBlogMigrationsDbContext(DbContextOptions<ZsqAbpBlogMigrationsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}
