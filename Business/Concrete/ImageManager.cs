using AutoMapper;
using Business.Abstract;
using Business.DTOs.Certificate;
using Business.DTOs.Cities;
using Business.DTOs.Image;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        IMapper _mapper;

        public ImageManager(IImageDal imageDal, IMapper mapper)
        {
            _imageDal = imageDal;
            _mapper = mapper;
        }

        public async Task<CreatedImageResponse> Add(CreateImageRequest createImageRequest)
        {

            Image image = _mapper.Map<Image>(createImageRequest);
            Image createdImage = await _imageDal.AddAsync(image);
            CreatedImageResponse createdImageResponse = _mapper.Map<CreatedImageResponse>(createdImage);
            return createdImageResponse;
        }

        public async Task<DeletedImageResponse> Delete(DeleteImageRequest deleteImageRequest)
        {
            Image image = _mapper.Map<Image>(deleteImageRequest);
            Image deletedImage = await _imageDal.DeleteAsync(image);
            DeletedImageResponse deletedImageResponse = _mapper.Map<DeletedImageResponse>(deletedImage);
            return deletedImageResponse;
        }

        public async Task<IPaginate<GetListImageResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _imageDal.GetListAsync(include: a => a.Include(a => a.User),
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListImageResponse>>(data);
            return result;
        }

        public async Task<UpdatedImageResponse> Update(UpdateImageRequest updateImageRequest)
        {
            Image image = _mapper.Map<Image>(updateImageRequest);
            Image updatedImage = await _imageDal.UpdateAsync(image);
            UpdatedImageResponse updatedImageResponse = _mapper.Map<UpdatedImageResponse>(updatedImage);
            return updatedImageResponse;
        }
    }
}
