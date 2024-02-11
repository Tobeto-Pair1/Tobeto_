namespace Business.DTOs.BlogsPress;

public class UpdateBlogPressRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}
