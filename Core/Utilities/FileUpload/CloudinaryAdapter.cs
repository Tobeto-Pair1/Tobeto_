using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.CrossCuttingConcrens.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.FileUpload;
public class CloudinaryAdapter : IFileUploadAdapter
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryAdapter(IConfiguration configuration)
    {
        Account account = configuration.GetSection("CloudinaryAccount").Get<Account>();
        _cloudinary = new Cloudinary(account);
    }

    public async Task<string> UploadImage(IFormFile file)
    {
        await FileMustBeInImageFormat(file);
        var fileUploadResponse = new ImageUploadResult();

        using (var stream = file.OpenReadStream())
        {
            var parameters = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream)
            };
            fileUploadResponse = await _cloudinary.UploadAsync(parameters);
        }
        return fileUploadResponse.SecureUri.AbsoluteUri;
    }


    public async Task DeleteImage(string imageUrl)
    {
        DeletionParams deletionParams = new(GetPublicId(imageUrl));
        await _cloudinary.DestroyAsync(deletionParams);
    }

    public async Task<string> UpdateImage(IFormFile formFile, string imageUrl)
    {
        await FileMustBeInImageFormat(formFile);

        await DeleteImage(imageUrl);
        return await UploadImage(formFile);
    }
    private string GetPublicId(string imageUrl)
    {
        int startIndex = imageUrl.LastIndexOf('/') + 1;
        int endIndex = imageUrl.LastIndexOf('.');
        int length = endIndex - startIndex;
        return imageUrl.Substring(startIndex, length);
    }

    protected async Task FileMustBeInImageFormat(IFormFile formFile)
    {
        List<string> extensions = new() { ".jpg", ".png", ".jpeg", ".webp" };

        string extension = Path.GetExtension(formFile.FileName).ToLower();
        if (!extensions.Contains(extension))
            throw new BusinessException("Unsupported format");
        await Task.CompletedTask;
    }
}