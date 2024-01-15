namespace Business.DTOs.Image
{
    public class UpdateImageRequest
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }
        public Guid UserId { get; set; }
    }

}
