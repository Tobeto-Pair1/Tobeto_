using AutoMapper;
using Business.DTOs.Certificate;
using Core.DataAccess.Dynamic;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CertificateMappingProfile : Profile
    {
        public CertificateMappingProfile()
        {
            CreateMap<Certificate, CreatedCertificateResponse>().ReverseMap();
            CreateMap<Certificate, CreateCertificateRequest>().ReverseMap();

            CreateMap<Certificate, DeleteCertificateRequest>().ReverseMap();
            CreateMap<Certificate, DeletedCertificateResponse>().ReverseMap();

            CreateMap<Certificate, UpdateCertificateRequest>().ReverseMap();
            CreateMap<Certificate, UpdatedCertificateResponse>().ReverseMap();

            CreateMap<Certificate, GetListCertificateResponse>().ReverseMap();
            CreateMap<Paginate<Certificate>, Paginate<GetListCertificateResponse>>().ReverseMap();
        }
    }
}
