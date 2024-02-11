namespace Business.DTOs.Blogs
{
    public class GetBlogResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}