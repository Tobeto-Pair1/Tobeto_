using AutoMapper;
using Business.DTOs.Certificate;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

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

        CreateMap<Certificate, GetListCertificateResponse>()
            .ForMember(c => c.Extension, opt => opt.MapFrom(c => Path.GetExtension(c.FileName)))
            .ReverseMap();
        CreateMap<Paginate<Certificate>, Paginate<GetListCertificateResponse>>().ReverseMap();
    }
}
