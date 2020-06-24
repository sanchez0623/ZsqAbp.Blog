using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using ZsqAbp.Blog.Domain.Blog;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }
    }
}
