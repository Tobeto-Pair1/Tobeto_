using Business.DTOs.Image;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService
    {
        Task<CreatedImageResponse> Add(CreateImageRequest createImageRequest);
        Task<DeletedImageResponse> Delete(DeleteImageRequest deleteImageRequest);
        Task<UpdatedImageResponse> Update(UpdateImageRequest updateImageRequest);
    }
}
