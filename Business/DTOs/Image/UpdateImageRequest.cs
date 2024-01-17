using Microsoft.AspNetCore.Http;

namespace Business.DTOs.Image
{
    public class UpdateImageRequest
    {
        public Guid Id { get; set; }
        public IFormFile? File { get; set; }
        public string Description { get; set; }
    }

}
