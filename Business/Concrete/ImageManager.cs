using AutoMapper;
using Business.Abstract;
using Business.DTOs.Image;
using Business.Rules;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Utilities.FileUpload;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concrete;

public class ImageManager : IImageService
{
    private readonly IImageDal _imageDal;
    private readonly IMapper _mapper;
    private readonly IFileUploadAdapter _fileUploadAdapter;
    private readonly ImageBusinessRules _ımageBusinessRules;


    public ImageManager(IImageDal imageDal, IMapper mapper, IFileUploadAdapter fileUploadAdapter, ImageBusinessRules ımageBusinessRules)
    {
        _imageDal = imageDal;
        _mapper = mapper;
        _fileUploadAdapter = fileUploadAdapter;
        _ımageBusinessRules = ımageBusinessRules;
    }

    public async Task<CreatedImageResponse> Add(CreateImageRequest createImageRequest)
    {
        await _ımageBusinessRules.FileMustBeInImageFormat(createImageRequest.File);
        Image image = _mapper.Map<Image>(createImageRequest);

        image.FileName = createImageRequest.File.FileName;
        image.FileUrl = await _fileUploadAdapter.Upload(createImageRequest.File);

        Image createdImage = await _imageDal.AddAsync(image);
        CreatedImageResponse createdImageResponse = _mapper.Map<CreatedImageResponse>(createdImage);
        return createdImageResponse;
    }

    public async Task<DeletedImageResponse> Delete(DeleteImageRequest deleteImageRequest)
    {
        Image? image = await _imageDal.GetAsync(f => f.Id == deleteImageRequest.Id);
        await _fileUploadAdapter.Delete(image.FileUrl);

        await _imageDal.DeleteAsync(image);
        DeletedImageResponse deletedImageResponse = _mapper.Map<DeletedImageResponse>(image);
        return deletedImageResponse;
    }
    public async Task<IPaginate<GetListImageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _imageDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListImageResponse>>(data);
        return result;
    }
    public async Task<UpdatedImageResponse> Update(UpdateImageRequest updateImageRequest)
    {
        Image? image = await _imageDal.GetAsync(predicate: f => f.Id == updateImageRequest.Id);
        image = _mapper.Map(updateImageRequest, image);

        image.FileUrl = await _fileUploadAdapter.Update(updateImageRequest.File, image.FileUrl);

        await _imageDal.UpdateAsync(image);
        UpdatedImageResponse updatedImageResponse = _mapper.Map<UpdatedImageResponse>(image);
        return updatedImageResponse;
    }


}
