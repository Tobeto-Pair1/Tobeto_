namespace Business.DTOs.Categories;

public class CreatedCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ParentName { get; set; }
}
