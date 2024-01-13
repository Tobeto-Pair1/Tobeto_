using Business.DTOs.Image;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService
    {
        Task<IPaginate<GetListImageResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedImageResponse> Add(CreateImageRequest createImageRequest);

        Task<UpdatedImageResponse> Update(UpdateImageRequest updateImageRequest);

        Task<DeletedImageResponse> Delete(DeleteImageRequest deleteImageRequest);
    }
}
