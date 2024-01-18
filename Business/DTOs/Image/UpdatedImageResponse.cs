namespace Business.DTOs.Image
{
    public class UpdatedImageResponse
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string Description { get; set; }
    }

}
