using AutoMapper;
using Business.Abstract;
using Business.DTOs.Categories;
using Business.DTOs.Company;
using Business.DTOs.CourseType;
using Business.DTOs.Requests;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;
public class CourseTypeManager : ICourseTypeService
{


   private readonly ICourseTypeDal _courseTypeDal;
    private readonly IMapper _mapper;

    public CourseTypeManager(ICourseTypeDal courseTypeDal, IMapper mapper)
    {
        _courseTypeDal = courseTypeDal;
        _mapper = mapper;
    }

    public async Task<CreatedCourseTypeResponse> Add(CreateCourseTypeRequest createCourseTypeRequest)
    {
        CourseType courseType = _mapper.Map<CourseType>(createCourseTypeRequest);
        CourseType createdCourseType = await _courseTypeDal.AddAsync(courseType);
        CreatedCourseTypeResponse createdCourseTypeResponse = _mapper.Map<CreatedCourseTypeResponse>(createdCourseType);

        return createdCourseTypeResponse;
    }

    public async Task<DeletedCourseTypeResponse> Delete(DeleteCourseTypeRequest deleteCourseTypeRequest)
    {
        CourseType courseType = _mapper.Map<CourseType>(deleteCourseTypeRequest);
        CourseType deletedCourseType = await _courseTypeDal.DeleteAsync(courseType);
        DeletedCourseTypeResponse deletedCourseTypeResponse = _mapper.Map<DeletedCourseTypeResponse>(deletedCourseType);
       
        return deletedCourseTypeResponse;
    }

    public async Task<IPaginate<GetListCourseTypeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _courseTypeDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
        var result = _mapper.Map<Paginate<GetListCourseTypeResponse>>(data);

        return result;
    }

    public async Task<UpdatedCourseTypeResponse> Update(UpdateCourseTypeRequest updateCourseTypeRequest)
    {
        CourseType courseType = _mapper.Map<CourseType>(updateCourseTypeRequest);
        CourseType updatedCourseType = await _courseTypeDal.UpdateAsync(courseType);
        UpdatedCourseTypeResponse updatedCourseTypeResponse = _mapper.Map<UpdatedCourseTypeResponse>(updatedCourseType);
        return updatedCourseTypeResponse;
    }
}
