namespace Business.DTOs.Image
{
    public class CreateImageRequest
    {
        public string? ImageUrl { get; set; }
        public Guid UserId { get; set; }
    }

}
