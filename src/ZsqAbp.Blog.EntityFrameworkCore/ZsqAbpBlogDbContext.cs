using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using ZsqAbp.Blog.Domain.Blog;
using ZsqAbp.Blog.Domain.Wallpaper;

namespace ZsqAbp.Blog.EntityFrameworkCore
{
    [ConnectionStringName("MySql")]
    public class ZsqAbpBlogDbContext : AbpDbContext<ZsqAbpBlogDbContext>
    {
        public ZsqAbpBlogDbContext(DbContextOptions<ZsqAbpBlogDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<FriendLink> FriendLinks { get; set; }

        public DbSet<Wallpaper> Wallpapers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }
    }
}
