using System.Collections.Generic;
using System.Threading.Tasks;
using ZsqAbp.Blog.Application.Contracts.Blog;
using ZsqAbp.Blog.ToolKits.Base;

namespace ZsqAbp.Blog.Application.Blog
{
    public partial interface IBlogService
    {
        /// <summary>
        /// 查询标签列表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync();

        /// <summary>
        /// 获取标签名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> GetTagAsync(string name);
    }
}
