using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileUpload;

public interface IFileUploadAdapter
{
    Task<string> UploadImage(IFormFile file);

    Task DeleteImage(string imageUrl);
    Task<string> UpdateImage(IFormFile formFile, string imageUrl);
}
