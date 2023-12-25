namespace Business.DTOs.Categories;

public class CreateCategoryRequest
{
    public string Name { get; set; }

    //eklendi
    public string ParentName { get; set; }
}



