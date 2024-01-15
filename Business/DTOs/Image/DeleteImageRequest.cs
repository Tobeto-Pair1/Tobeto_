namespace Business.DTOs.Image
{
    public class DeleteImageRequest
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }
    }

}
