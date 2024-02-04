using AutoMapper;
using Business.DTOs.Blogs;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class BlogMappingProfile : Profile
{
    public BlogMappingProfile()
    {
        CreateMap<Blog, CreateBlogRequest>().ReverseMap();
        CreateMap<Blog, CreatedBlogResponse>().ReverseMap();

        CreateMap<Blog, DeleteBlogRequest>().ReverseMap();
        CreateMap<Blog, DeletedBlogResponse>().ReverseMap();

        CreateMap<Blog, UpdateBlogRequest>().ReverseMap();
        CreateMap<Blog, UpdatedBlogResponse>().ReverseMap();

        CreateMap<Blog, GetListBlogResponse>().ReverseMap();
        CreateMap<Paginate<Blog>, Paginate<GetListBlogResponse>>().ReverseMap();
    }
    
}
