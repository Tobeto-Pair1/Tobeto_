using AutoMapper;
using Business.DTOs.Image;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ImageMappingProfile :Profile
    {
        public ImageMappingProfile()
        {
            CreateMap<Image, CreateImageRequest>().ReverseMap();
            CreateMap<Image, CreatedImageResponse>().ReverseMap();


            CreateMap<Image, UpdateImageRequest>().ReverseMap();
            CreateMap<Image, UpdatedImageResponse>().ReverseMap();


            CreateMap<Image, DeleteImageRequest>().ReverseMap();
            CreateMap<Image, DeletedImageResponse>().ReverseMap();


            CreateMap<Image, GetListImageResponse>().ReverseMap();
            CreateMap<Paginate<Image>, Paginate<GetListImageResponse>>().ReverseMap();

        }
    }
}
