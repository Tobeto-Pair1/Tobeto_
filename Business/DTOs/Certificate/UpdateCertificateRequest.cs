using Microsoft.AspNetCore.Http;

namespace Business.DTOs.Certificate;

public class UpdateCertificateRequest
{
    public Guid Id { get; set; }
    public IFormFile? File { get; set; }
}
