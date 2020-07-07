﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZsqAbp.Blog.Application.Contracts.Blog
{
    public class QueryPostForAdminDto : QueryPostDto
    {
        /// <summary>
        /// Posts
        /// </summary>
        public new IEnumerable<PostBriefForAdminDto> Posts { get; set; }
    }
}
