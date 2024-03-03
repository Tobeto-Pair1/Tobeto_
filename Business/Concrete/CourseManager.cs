using AutoMapper;
using Business.Abstract;
using Business.DTOs.Blogs;
using Business.DTOs.Categories;
using Business.DTOs.Course;
using Business.DTOs.Users;
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

namespace Business.Concrete
{
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
    }
}
