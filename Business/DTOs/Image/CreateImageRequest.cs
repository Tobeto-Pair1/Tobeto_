using Microsoft.AspNetCore.Http;

namespace Business.DTOs.Image
{
    public class CreateImageRequest
    {
        public IFormFile File { get; set; }
        public string? Description { get; set; }
        public string? Extension { get; set; }
    }

}
