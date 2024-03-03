using AutoMapper;
using Business.DTOs.ContactInformations;
using Core.DataAccess.Dynamic;
using Entities.Concretes;

namespace Business.Profiles;

public class ContactInformationMappingProfile:Profile
{
    public ContactInformationMappingProfile()
    {
        CreateMap<ContactInformation, CreateContactInformationRequest>().ReverseMap();
        CreateMap<ContactInformation, CreatedContactInformationResponse>().ReverseMap();

        CreateMap<ContactInformation, DeleteContactInformationRequest>().ReverseMap();
        CreateMap<ContactInformation, DeletedContactInformationResponse>().ReverseMap();

        CreateMap<ContactInformation, UpdateContactInformationRequest>().ReverseMap();
        CreateMap<ContactInformation, UpdatedContactInformationResponse>().ReverseMap();

        CreateMap<ContactInformation, GetListContactInformationResponse>().ReverseMap();
        CreateMap<Paginate<ContactInformation>, Paginate<GetListContactInformationResponse>>().ReverseMap();
    }
}
