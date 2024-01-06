using Business.DTOs.SocialMedias;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ISocialMediaService
{
    Task<IPaginate<GetListSocialMediaResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedSocialMediaResponse> Add(CreateSocialMediaRequest createSocialMediaRequest);
    Task<DeletedSocialMediaResponse> Delete(DeleteSocialMediaRequest deleteSocialMediaRequest);
    Task<UpdateSocialMediaResponse> Update(UpdateSocialMediaRequest updateSocialMediaRequest);
}
