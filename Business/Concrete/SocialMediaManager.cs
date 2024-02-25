using AutoMapper;
using Business.DTOs.SocialMedias;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Abstract;

public class SocialMediaManager : ISocialMediaService
{
    private readonly ISocialMediaDal _socialMediaDal;
    private readonly IMapper _mapper;

    public SocialMediaManager(ISocialMediaDal socialMediaDal, IMapper mapper)
    {
        _socialMediaDal = socialMediaDal;
        _mapper = mapper;
    }


    public async Task<CreatedSocialMediaResponse> Add(CreateSocialMediaRequest createSocialMediaRequest)
    {
        SocialMedia socialMedia = _mapper.Map<SocialMedia>(createSocialMediaRequest);
        SocialMedia createdSocialMedia = await _socialMediaDal.AddAsync(socialMedia);
        CreatedSocialMediaResponse socialMediaResponse = _mapper.Map<CreatedSocialMediaResponse>(createdSocialMedia);
        return socialMediaResponse;
    }

    public async Task<DeletedSocialMediaResponse> Delete(DeleteSocialMediaRequest deleteSocialMediaRequest)
    {
        SocialMedia socialMedia = await _socialMediaDal.GetAsync(u => u.Id == deleteSocialMediaRequest.Id);
        SocialMedia deletedSocialMedia = await _socialMediaDal.DeleteAsync(socialMedia);
        DeletedSocialMediaResponse socialMediaResponse = _mapper.Map<DeletedSocialMediaResponse>(deletedSocialMedia);
        return socialMediaResponse;
    }

    public async Task<IPaginate<GetListSocialMediaResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _socialMediaDal.GetListAsync(
            index:pageRequest.PageIndex,
            size:pageRequest.PageSize);
        var result = _mapper.Map<Paginate<GetListSocialMediaResponse>>(data);
        return result;
    }

    public async Task<UpdatedSocialMediaResponse> Update(UpdateSocialMediaRequest updateSocialMediaRequest)
    {
        SocialMedia socialMedia = await _socialMediaDal.GetAsync(u => u.Id == updateSocialMediaRequest.Id);
        _mapper.Map(updateSocialMediaRequest, socialMedia);
        SocialMedia updatedSocialMedia = await _socialMediaDal.UpdateAsync(socialMedia);
        UpdatedSocialMediaResponse socialMediaResponse = _mapper.Map<UpdatedSocialMediaResponse>(updatedSocialMedia);
        return socialMediaResponse;
    }
}
