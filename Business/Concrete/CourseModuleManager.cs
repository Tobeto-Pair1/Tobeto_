using AutoMapper;
using Business.Abstract;
using Business.DTOs.Blogs;
using Business.DTOs.Course;
using Business.DTOs.CourseModule;
using Business.DTOs.Employees;
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
    public class CourseModuleManager : ICourseModuleService
    {
        ICourseModuleDal _courseModuleDal;
        IMapper _mapper;

        public CourseModuleManager(ICourseModuleDal courseModuleDal, IMapper mapper)
        {
            _courseModuleDal = courseModuleDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseModuleResponse> Add(CreateCourseModuleRequest createCourseModuleRequest)
        {
            CourseModule courseModule = _mapper.Map<CourseModule>(createCourseModuleRequest);
            CourseModule createdCourseModule = await _courseModuleDal.AddAsync(courseModule);
            CreatedCourseModuleResponse createdCourseModuleResponse = _mapper.Map<CreatedCourseModuleResponse>(createdCourseModule);
            return createdCourseModuleResponse;
        }

        public async  Task<DeletedCourseModuleResponse> Delete(DeleteCourseModuleRequest deleteCourseModuleRequest)
        {
            CourseModule? courseModule = await _courseModuleDal.GetAsync(u => u.Id == deleteCourseModuleRequest.Id);
            await _courseModuleDal.DeleteAsync(courseModule);
            DeletedCourseModuleResponse deletedCourseModuleResponse = _mapper.Map<DeletedCourseModuleResponse>(courseModule);
            return deletedCourseModuleResponse;
        }

        public async Task<IPaginate<GetListCourseModuleResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _courseModuleDal.GetListAsync(include: l => l.
                   Include(l => l.Course),
                    index: pageRequest.PageIndex,
                    size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListCourseModuleResponse>>(data);
            return result;
        }

        public async Task<UpdatedCourseModuleResponse> Update(UpdateCourseModuleRequest updateCourseModuleRequest)
        {
            CourseModule? courseModule = await _courseModuleDal.GetAsync(u => u.Id == updateCourseModuleRequest.Id);
            _mapper.Map(updateCourseModuleRequest, courseModule);
            CourseModule updateCourseModule = await _courseModuleDal.UpdateAsync(courseModule);
            UpdatedCourseModuleResponse updatedCourseModuleResponse = _mapper.Map<UpdatedCourseModuleResponse>(updateCourseModule);
            return updatedCourseModuleResponse;
        }
    }
}
