using AutoMapper;
using Business.Abstract;
using Business.DTOs.AboutOfCourses;
using Business.DTOs.Blogs;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class AboutOfCourseManager : IAboutOfCourseService
{
    IAboutOfCourseDal _aboutOfCourseDal;
    IMapper _mapper;

    public AboutOfCourseManager(IAboutOfCourseDal aboutOfCourseDal, IMapper mapper)
    {
        _aboutOfCourseDal = aboutOfCourseDal;
        _mapper = mapper;
    }

    public async Task<CreatedAboutOfCourseResponse> Add(CreateAboutOfCourseRequest createAboutOfCourseRequest)
    {
        AboutOfCourse aboutOfCourse = _mapper.Map<AboutOfCourse>(createAboutOfCourseRequest);
        AboutOfCourse createdAboutOfCourse = await _aboutOfCourseDal.AddAsync(aboutOfCourse);
        CreatedAboutOfCourseResponse createdAboutOfCourseResponse = _mapper.Map<CreatedAboutOfCourseResponse>(createdAboutOfCourse);
        return createdAboutOfCourseResponse;
    }

    public async Task<DeletedAboutOfCourseResponse> Delete(DeleteAboutOfCourseRequest deleteAboutOfCourseRequest)
    {
        AboutOfCourse? aboutOfCourse = await _aboutOfCourseDal.GetAsync(u => u.Id == deleteAboutOfCourseRequest.Id);
        await _aboutOfCourseDal.DeleteAsync(aboutOfCourse);
        DeletedAboutOfCourseResponse deletedAboutOfCourseResponse = _mapper.Map<DeletedAboutOfCourseResponse>(aboutOfCourse);
        return deletedAboutOfCourseResponse;
    }

    public async Task<IPaginate<GetListAboutOfCourseResponse>> GetListAsync(PageRequest pageRequest)
    {

        var data = await _aboutOfCourseDal.GetListAsync(include: a => a.Include(a => a.Category).
        Include(a => a.Manufacturer),
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListAboutOfCourseResponse>>(data);
        return result;
    }

    public async Task<UpdatedAboutOfCourseResponse> Update(UpdateAboutOfCourseRequest updateAboutOfCourseRequest)
    {
        AboutOfCourse? aboutOfCourse = await _aboutOfCourseDal.GetAsync(u => u.Id == updateAboutOfCourseRequest.Id);
        _mapper.Map(updateAboutOfCourseRequest, aboutOfCourse);
        AboutOfCourse updateAboutOfCourse = await _aboutOfCourseDal.UpdateAsync(aboutOfCourse);
        UpdatedAboutOfCourseResponse updatedAboutOfCourseResponse = _mapper.Map<UpdatedAboutOfCourseResponse>(updateAboutOfCourse);
        return updatedAboutOfCourseResponse;
    }
}
