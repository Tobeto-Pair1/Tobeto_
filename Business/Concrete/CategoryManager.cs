using AutoMapper;
using Business.Abstract;
using Business.DTOs.Categories;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    ICategoryDal _categoryDal;
    IMapper _mapper;

    public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
    {
        _categoryDal = categoryDal;
        _mapper = mapper;
    }

    public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
    {
        Category category = _mapper.Map<Category>(createCategoryRequest);
        Category createdCategory = await _categoryDal.AddAsync(category);
        CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);

        return createdCategoryResponse;
    }

    public async Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest)
    {
        Category category = _mapper.Map<Category>(deleteCategoryRequest);
        Category deletedCategory = await _categoryDal.DeleteAsync(category);
        DeletedCategoryResponse deletedCategoryResponse = _mapper.Map<DeletedCategoryResponse>(deletedCategory);
        return deletedCategoryResponse;
    }

    public async Task<IPaginate<GetListCategoryResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _categoryDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
        var result = _mapper.Map<Paginate<GetListCategoryResponse>>(data);

        return result;
    }

    public async Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest)
    {
        Category category = _mapper.Map<Category>(updateCategoryRequest);
        Category updatedCategory = await _categoryDal.UpdateAsync(category);
        UpdatedCategoryResponse updatedCategoryResponse = _mapper.Map<UpdatedCategoryResponse>(updatedCategory);
        return updatedCategoryResponse;
    }
}
