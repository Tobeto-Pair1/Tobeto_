using Microsoft.AspNetCore.Http;

namespace Business.DTOs.Certificate;

public class CreateCertificateRequest
{
    public Guid UserId { get; set; }
    public IFormFile File { get; set; }

}
