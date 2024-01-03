using AutoMapper;
using Business.DTOs.Company;
using Business.DTOs.Requests;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CompanyMappingProfile: Profile
    {
        public CompanyMappingProfile()

        {
            CreateMap<Company, CreatedCompanyResponse>().ReverseMap();

            CreateMap<Company, CreateCompanyRequest>().ReverseMap();



            CreateMap<Company, DeletedCompanyResponse>().ReverseMap();

            CreateMap<Company, DeleteCompanyRequest>().ReverseMap();


            CreateMap<Company, UpdateCompanyRequest>().ReverseMap();

            CreateMap<Company, UpdatedCompanyResponse>().ReverseMap();


            CreateMap<Company, GetListCompanyResponse>().
                ForMember(destinationMember: a => a.ExperienceId,
            memberOptions: opt => opt.MapFrom(a => a.Id))
                .ReverseMap();


            CreateMap<Paginate<Company>, Paginate<GetListCompanyResponse>>()
                .ReverseMap();
        }
    }
}
