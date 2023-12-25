﻿using AutoMapper;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
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


            CreateMap<Company, GetListCompanyResponse>().ReverseMap();


            CreateMap<Paginate<Company>, Paginate<GetListCompanyResponse>>().ReverseMap();
        }
    }
}