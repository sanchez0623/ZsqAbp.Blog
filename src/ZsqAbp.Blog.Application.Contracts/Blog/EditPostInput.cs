using System;
using System.Collections.Generic;
using System.Text;

namespace ZsqAbp.Blog.Application.Contracts.Blog
{
    public class EditPostInput : PostDto
    {
        /// <summary>
        /// 标签列表
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}
