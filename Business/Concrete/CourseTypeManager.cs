﻿using AutoMapper;
using Business.Abstract;
using Business.DTOs.Blogs;
using Business.DTOs.CourseType;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;

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
        CourseType? courseType = await _courseTypeDal.GetAsync(u => u.Id == deleteCourseTypeRequest.Id);
        await _courseTypeDal.DeleteAsync(courseType);
        DeletedCourseTypeResponse deletedCourseTypeResponse = _mapper.Map<DeletedCourseTypeResponse>(courseType);
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
        CourseType? courseType = await _courseTypeDal.GetAsync(u => u.Id == updateCourseTypeRequest.Id);
        _mapper.Map(updateCourseTypeRequest, courseType);
        CourseType updateCourseType = await _courseTypeDal.UpdateAsync(courseType);
        UpdatedCourseTypeResponse updatedCourseTypeResponse = _mapper.Map<UpdatedCourseTypeResponse>(updateCourseType);
        return updatedCourseTypeResponse;
    }
}
