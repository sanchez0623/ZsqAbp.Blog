﻿using ZsqAbp.Blog.Domain.Shared.Enum;

namespace ZsqAbp.Blog.Application.Contracts.Wallpaper
{
    public class WallpaperJobItem<T>
    {
        /// <summary>
        /// <see cref="Result"/>
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public WallpaperEnum Type { get; set; }
    }
}
