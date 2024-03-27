using AutoMapper;
using Business.Abstract;
using Business.DTOs.Course;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Business.Concrete;

public class CourseManager : ICourseService
{
    ICourseDal _courseDal;
    IMapper _mapper;

    public CourseManager(ICourseDal courseDal, IMapper mapper)
    {
        _courseDal = courseDal;
        _mapper = mapper;
    }

    public async Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest)
    {
        Course course = _mapper.Map<Course>(createCourseRequest);
        Course createdCourse = await _courseDal.AddAsync(course);
        CreatedCourseResponse createdCourseResponse = _mapper.Map<CreatedCourseResponse>(createdCourse);
        return createdCourseResponse;
    }

    public async Task<DeletedCourseResponse> Delete(DeleteCourseRequest deleteCourseRequest)
    {
        Course? course = await _courseDal.GetAsync(u => u.Id == deleteCourseRequest.Id);
        await _courseDal.DeleteAsync(course);
        DeletedCourseResponse deletedCourseResponse = _mapper.Map<DeletedCourseResponse>(course);
        return deletedCourseResponse;
    }

    public async Task<IPaginate<GetListCourseResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _courseDal.GetListAsync(include: l => l.
               Include(l => l.CourseType),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListCourseResponse>>(data);
        return result;
    }

    public async Task<UpdatedCourseResponse> Update(UpdateCourseRequest updateCourseRequest)
    {
        Course? course = await _courseDal.GetAsync(u => u.Id == updateCourseRequest.Id);
        _mapper.Map(updateCourseRequest, course);
        Course updateCourse = await _courseDal.UpdateAsync(course);
        UpdatedCourseResponse updatedCourseResponse = _mapper.Map<UpdatedCourseResponse>(updateCourse);
        return updatedCourseResponse;
    }
    public async Task<GetListCourseByDynamicResponse> GetListModelByDynamicQuery(PageRequest pageRequest, DynamicQuery dynamic)
    {
        //car models
        IPaginate<Course> models = await _courseDal.GetListByDynamicAsync(dynamic, include:
                                      m => m.Include(c => c.CourseType),
                                      index: pageRequest.PageIndex,
                                      size: pageRequest.PageSize
                                      );
        //dataModel
        GetListCourseByDynamicResponse mappedModels = _mapper.Map<GetListCourseByDynamicResponse>(models);
        return mappedModels;
    }
}
