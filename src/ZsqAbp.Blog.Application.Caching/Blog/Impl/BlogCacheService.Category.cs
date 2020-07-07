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
        private const string KEY_QueryCategories = "Blog:Category:QueryCategories";
        private const string KEY_GetCategory = "Blog:Category:GetCategory-{0}";

        /// <summary>
        /// 查询分类列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync(Func<Task<ServiceResult<IEnumerable<QueryCategoryDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_QueryCategories, factory, CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetCategoryAsync(string name, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetCategory.FormatWith(name), factory, CacheStrategy.ONE_DAY);
        }
    }
}
