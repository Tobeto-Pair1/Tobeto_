namespace Business.DTOs.Blogs;

public class GetListBlogResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime CreatedDate { get; set; }
}
