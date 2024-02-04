using AutoMapper;
using Business.Abstract;
using Business.DTOs.Certificate;
using Business.DTOs.CourseModule;
using Business.DTOs.CourseStudent;
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
    public class CourseStudentManager : ICourseStudentService
    {
        ICourseStudentDal _courseStudentDal;
        IMapper _mapper;

        public CourseStudentManager(ICourseStudentDal courseStudentDal, IMapper mapper)
        {
            _courseStudentDal = courseStudentDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseStudentResponse> Add(CreateCourseStudentRequest createCourseStudentRequest)
        {
            CourseStudent courseStudent = _mapper.Map<CourseStudent>(createCourseStudentRequest);
            CourseStudent createdCourseStudent = await _courseStudentDal.AddAsync(courseStudent);
            CreatedCourseStudentResponse createdCourseStudentResponse = _mapper.Map<CreatedCourseStudentResponse>(createdCourseStudent);
            return createdCourseStudentResponse;
        }

        public async Task<DeletedCourseStudentResponse> Delete(DeleteCourseStudentRequest deleteCourseStudentRequest)
        {
            CourseStudent courseStudent = _mapper.Map<CourseStudent>(deleteCourseStudentRequest);
            CourseStudent deletedCourseStudent = await _courseStudentDal.DeleteAsync(courseStudent);
            DeletedCourseStudentResponse deletedCourseStudentResponse = _mapper.Map<DeletedCourseStudentResponse>(deletedCourseStudent);
            return deletedCourseStudentResponse;
        }

        public async Task<IPaginate<GetListCourseStudentResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _courseStudentDal.GetListAsync(include: l => l.
                  Include(l => l.Course).
                  Include(l => l.Student),
                   index: pageRequest.PageIndex,
                   size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListCourseStudentResponse>>(data);
            return result;
        }

        public async Task<UpdatedCourseStudentResponse> Update(UpdateCourseStudentRequest updateCourseStudentRequest)
        {
            CourseStudent courseStudent = _mapper.Map<CourseStudent>(updateCourseStudentRequest);
            CourseStudent updatedCourseStudent = await _courseStudentDal.UpdateAsync(courseStudent);
            UpdatedCourseStudentResponse updatedCourseStudentResponse = _mapper.Map<UpdatedCourseStudentResponse>(updatedCourseStudent);
            return updatedCourseStudentResponse;
        }
    }
}
