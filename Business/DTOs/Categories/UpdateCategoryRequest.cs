namespace Business.DTOs.Categories;

public class UpdateCategoryRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ParentName { get; set; }

}



