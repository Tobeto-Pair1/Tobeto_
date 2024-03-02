using Microsoft.AspNetCore.Http;

namespace Business.DTOs.Image;

public class CreateImageRequest
{
    public IFormFile File { get; set; }
}
