namespace Business.DTOs.Certificate
{
    public class CreateCertificateRequest
    {
        public Guid UserId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
    }
}
