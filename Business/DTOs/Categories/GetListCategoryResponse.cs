namespace Business.DTOs.Categories;

public class GetListCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ParentName { get; set; }
}