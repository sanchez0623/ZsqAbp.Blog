using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZsqAbp.Blog.Application.Contracts.Blog;
using ZsqAbp.Blog.ToolKits.Base;
using static ZsqAbp.Blog.Domain.Shared.ZsqAbpBlogConsts;

namespace ZsqAbp.Blog.Application.Caching.Blog.Impl
{
    public partial class BlogCacheService
    {
        private const string KEY_QueryFriendLinks = "Blog:FriendLink:QueryFriendLinks";

        /// <summary>
        /// 查询友链列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<FriendLinkDto>>> QueryFriendLinksAsync(Func<Task<ServiceResult<IEnumerable<FriendLinkDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_QueryFriendLinks, factory, CacheStrategy.ONE_DAY);
        }
    }
}
