using AutoMapper;
using Business.Dtos.UserOperationClaims;
using Core.DataAccess.Dynamic;
using Core.Entities.Concrete;

namespace Business.Profiles;

public class UserOperationClaimMappingProfile : Profile
{
    public UserOperationClaimMappingProfile()
    {
        CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, CreateUserOperationClaimRequest>().ReverseMap();

        CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, DeleteUserOperationClaimRequest>().ReverseMap();

        CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, UpdateUserOperationClaimRequest>().ReverseMap();

        CreateMap<UserOperationClaim, GetListUserOperationClaimResponse>()
            .ForMember(o=>o.ClaimName, opt=>opt.MapFrom(o=>o.OperationClaim.Name))
            .ReverseMap();
        CreateMap<Paginate<UserOperationClaim>, Paginate<GetListUserOperationClaimResponse>>().ReverseMap();
    }
}
  