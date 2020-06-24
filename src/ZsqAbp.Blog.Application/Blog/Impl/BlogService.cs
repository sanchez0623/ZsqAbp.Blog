﻿using System;
using System.Threading.Tasks;
using ZsqAbp.Blog.Application.Contracts.Blog;
using ZsqAbp.Blog.Domain.Blog;
using ZsqAbp.Blog.Domain.Blog.Repositories;

namespace ZsqAbp.Blog.Application.Blog.Impl
{
    public class BlogService : ServiceBase, IBlogService
    {
        private readonly IPostRepository _postRepository;

        public BlogService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> InsertPostAsync(PostDto dto)
        {
            var entity = new Post
            {
                Title = dto.Title,
                Author = dto.Author,
                Url = dto.Url,
                Html = dto.Html,
                Markdown = dto.Markdown,
                CategoryId = dto.CategoryId,
                CreateTime = dto.CreateTime
            };

            var post = await _postRepository.InsertAsync(entity);
            return post != null;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);

            return true;
        }

        public async Task<bool> UpdatePostAsync(int id, PostDto dto)
        {
            var post = await _postRepository.GetAsync(id);

            post.Title = dto.Title;
            post.Author = dto.Author;
            post.Url = dto.Url;
            post.Html = dto.Html;
            post.Markdown = dto.Markdown;
            post.CategoryId = dto.CategoryId;
            post.CreateTime = dto.CreateTime;

            await _postRepository.UpdateAsync(post);

            return true;
        }

        public async Task<PostDto> GetPostAsync(int id)
        {
            var post = await _postRepository.GetAsync(id);

            return new PostDto
            {
                Title = post.Title,
                Author = post.Author,
                Url = post.Url,
                Html = post.Html,
                Markdown = post.Markdown,
                CategoryId = post.CategoryId,
                CreateTime = post.CreateTime
            };
        }
    }
}
