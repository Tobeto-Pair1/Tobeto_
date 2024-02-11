using AutoMapper;
using Business.DTOs.BlogsPress;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles;

public class BlogPressMappingProfile : Profile
{
    public BlogPressMappingProfile()
    {
        
        CreateMap<BlogPress, CreateBlogPressRequest>().ReverseMap();
        CreateMap<BlogPress, CreatedBlogPressResponse>().ReverseMap();

        CreateMap<BlogPress, DeleteBlogPressRequest>().ReverseMap();
        CreateMap<BlogPress, DeletedBlogPressResponse>().ReverseMap();

        CreateMap<BlogPress, UpdateBlogPressRequest>().ReverseMap();
        CreateMap<BlogPress, UpdatedBlogPressResponse>().ReverseMap();

        CreateMap<BlogPress, GetListBlogPressResponse>().ReverseMap();
        CreateMap<Paginate<BlogPress>, Paginate<GetListBlogPressResponse>>().ReverseMap();

        CreateMap<BlogPress, GetBlogPressResponse>().ReverseMap();
    }
}
