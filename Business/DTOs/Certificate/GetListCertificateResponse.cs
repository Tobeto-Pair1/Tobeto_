namespace Business.DTOs.Certificate;

public class GetListCertificateResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    public string Extension { get; set; }
    public DateTime CreatedDate { get; set; }
}
