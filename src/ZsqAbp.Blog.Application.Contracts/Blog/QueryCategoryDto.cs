﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZsqAbp.Blog.Application.Contracts.Blog
{
    public class QueryCategoryDto : CategoryDto
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int Count { get; set; }
    }
}
