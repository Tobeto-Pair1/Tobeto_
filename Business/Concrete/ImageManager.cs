using AutoMapper;
using Business.Abstract;
using Business.DTOs.Certificate;
using Business.DTOs.Cities;
using Business.DTOs.Image;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Utilities.FileUpload;
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
        private readonly IImageDal _imageDal;
        private readonly IMapper _mapper;
        private readonly IFileUploadAdapter _fileUploadAdapter;


        public ImageManager(IImageDal imageDal, IMapper mapper, IFileUploadAdapter fileUploadAdapter)
        {
            _imageDal = imageDal;
            _mapper = mapper;
            _fileUploadAdapter = fileUploadAdapter;
        }

        public async Task<CreatedImageResponse> Add(CreateImageRequest createImageRequest)
        {
            Image image = _mapper.Map<Image>(createImageRequest);

            image.FileName = createImageRequest.File.FileName;
            image.FileUrl = await _fileUploadAdapter.UploadImage(createImageRequest.File);

            Image createdImage = await _imageDal.AddAsync(image);
            CreatedImageResponse createdImageResponse = _mapper.Map<CreatedImageResponse>(createdImage);
            return createdImageResponse;
        }

        public async Task<DeletedImageResponse> Delete(DeleteImageRequest deleteImageRequest)
        {
            Image? image = await _imageDal.GetAsync(f => f.Id == deleteImageRequest.Id);
            await _fileUploadAdapter.DeleteImage(image.FileUrl);

            await _imageDal.DeleteAsync(image);
            DeletedImageResponse deletedImageResponse = _mapper.Map<DeletedImageResponse>(image);
            return deletedImageResponse;
        }

        public async Task<UpdatedImageResponse> Update(UpdateImageRequest updateImageRequest)
        {
            Image? image = await _imageDal.GetAsync(predicate: f => f.Id == updateImageRequest.Id);
          //  image = _mapper.Map<Image>(updateImageRequest);
            image = _mapper.Map(updateImageRequest, image);

            image.FileUrl = await _fileUploadAdapter.UpdateImage(updateImageRequest.File, image.FileUrl);

            await _imageDal.UpdateAsync(image);
            UpdatedImageResponse updatedImageResponse = _mapper.Map<UpdatedImageResponse>(image);
            return updatedImageResponse;
        }
    }
}
