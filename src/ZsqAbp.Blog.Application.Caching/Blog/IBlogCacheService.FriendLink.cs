using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZsqAbp.Blog.Application.Contracts.Blog;
using ZsqAbp.Blog.ToolKits.Base;

namespace ZsqAbp.Blog.Application.Caching.Blog
{
    public partial interface IBlogCacheService
    {
        /// <summary>
        /// 查询友链列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<FriendLinkDto>>> QueryFriendLinksAsync(Func<Task<ServiceResult<IEnumerable<FriendLinkDto>>>> factory);
    }
}
