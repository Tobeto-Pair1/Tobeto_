using Business.DTOs.Categories;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface ICategoryService
{
    Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest);

    Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest);
    Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest);
}