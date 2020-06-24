using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using ZsqAbp.Blog.Domain.Blog;
using ZsqAbp.Blog.Domain.Blog.Repositories;

namespace ZsqAbp.Blog.EntityFrameworkCore.Repositories.Blog
{
    public class PostRepository : EfCoreRepository<ZsqAbpBlogDbContext, Post, int>, IPostRepository
    {
        public PostRepository(IDbContextProvider<ZsqAbpBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
