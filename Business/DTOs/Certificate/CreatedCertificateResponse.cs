namespace Business.DTOs.Certificate
{
    public class CreatedCertificateResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

    }
}
