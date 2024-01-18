namespace Business.DTOs.Certificate
{
    public class UpdateCertificateRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
    }
}
