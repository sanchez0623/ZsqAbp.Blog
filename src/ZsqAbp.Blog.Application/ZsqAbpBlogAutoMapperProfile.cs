using AutoMapper;
using ZsqAbp.Blog.Application.Contracts.Blog;
using ZsqAbp.Blog.Domain.Blog;

namespace ZsqAbp.Blog.Application
{
    public class ZsqAbpBlogAutoMapperProfile : Profile
    {
        public ZsqAbpBlogAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();

            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<FriendLink, FriendLinkDto>();

            CreateMap<EditPostInput, Post>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
