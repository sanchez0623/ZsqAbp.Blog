using Volo.Abp.Domain.Repositories;

namespace ZsqAbp.Blog.Domain.Blog.Repositories
{
    public interface IPostRepository : IRepository<Post, int>
    {
    }
}
