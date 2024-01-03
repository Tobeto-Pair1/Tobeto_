using AutoMapper;
using Business.DTOs.Categories;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
        CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();
        CreateMap<Category, DeletedCategoryResponse>().ReverseMap();

        CreateMap<Category, DeleteCategoryRequest>().ReverseMap();


        CreateMap<Category, CreateCategoryRequest>().ReverseMap();


        CreateMap<Category, GetListCategoryResponse>().ReverseMap();

        CreateMap<Paginate<Category>, Paginate<GetListCategoryResponse>>().ReverseMap();

    }
}