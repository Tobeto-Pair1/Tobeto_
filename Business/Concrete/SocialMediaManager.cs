using AutoMapper;
using Business.DTOs.SocialMedias;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public class SocialMediaManager : ISocialMediaService
{
    ISocialMediaDal _socialMediaDal;
    IMapper _mapper;

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
        SocialMedia socialMedia = _mapper.Map<SocialMedia>(deleteSocialMediaRequest);
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

    public async Task<UpdateSocialMediaResponse> Update(UpdateSocialMediaRequest updateSocialMediaRequest)
    {
        SocialMedia socialMedia = _mapper.Map<SocialMedia>(updateSocialMediaRequest);
        SocialMedia updatedSocialMedia = await _socialMediaDal.UpdateAsync(socialMedia);
        UpdateSocialMediaResponse socialMediaResponse = _mapper.Map<UpdateSocialMediaResponse>(updatedSocialMedia);
        return socialMediaResponse;
    }
}
