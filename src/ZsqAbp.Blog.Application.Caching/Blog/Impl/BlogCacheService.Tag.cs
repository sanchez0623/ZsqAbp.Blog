using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZsqAbp.Blog.Application.Contracts.Blog;
using ZsqAbp.Blog.ToolKits.Base;
using ZsqAbp.Blog.ToolKits.Extensions;
using static ZsqAbp.Blog.Domain.Shared.ZsqAbpBlogConsts;

namespace ZsqAbp.Blog.Application.Caching.Blog.Impl
{
    public partial class BlogCacheService
    {
        private const string KEY_QueryTags = "Blog:Tag:QueryTags";
        private const string KEY_GetTag = "Blog:Tag:GetTag-{0}";

        /// <summary>
        /// 查询标签列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync(Func<Task<ServiceResult<IEnumerable<QueryTagDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_QueryTags, factory, CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 获取标签名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetTagAsync(string name, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetTag.FormatWith(name), factory, CacheStrategy.ONE_DAY);
        }
    }
}
