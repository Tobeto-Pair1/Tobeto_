using AutoMapper;
using Business.Abstract;
using Business.DTOs.Blogs;
using Business.DTOs.Certificate;
using Business.DTOs.CourseProgram;
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
    public class CourseProgramManager : ICourseProgramService
    {
        ICourseProgramDal _courseProgramDal;
        IMapper _mapper;

        public CourseProgramManager(ICourseProgramDal courseProgramDal, IMapper mapper)
        {
            _courseProgramDal = courseProgramDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseProgramResponse> Add(CreateCourseProgramRequest createCourseProgramRequest)
        {
            CourseProgram courseProgram = _mapper.Map<CourseProgram>(createCourseProgramRequest);
            CourseProgram createdCourseProgram = await _courseProgramDal.AddAsync(courseProgram);
            CreatedCourseProgramResponse createdCourseProgramResponse = _mapper.Map<CreatedCourseProgramResponse>(createdCourseProgram);
            return createdCourseProgramResponse;
        }

        public async Task<DeletedCourseProgramResponse> Delete(DeleteCourseProgramRequest deleteCourseProgramRequest)
        {
            CourseProgram? courseProgram = await _courseProgramDal.GetAsync(u => u.Id == deleteCourseProgramRequest.Id);
            await _courseProgramDal.DeleteAsync(courseProgram);
            DeletedCourseProgramResponse deletedCourseProgramResponse = _mapper.Map<DeletedCourseProgramResponse>(courseProgram);
            return deletedCourseProgramResponse;
        }

        public async Task<IPaginate<GetListCourseProgramResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _courseProgramDal.GetListAsync(include: a => a.
            Include(a => a.Course).
            Include(a=>a.Program),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListCourseProgramResponse>>(data);
            return result;
        }

        public async Task<UpdatedCourseProgramResponse> Update(UpdateCourseProgramRequest updateCourseProgramRequest)
        {
            CourseProgram? courseProgram = await _courseProgramDal.GetAsync(u => u.Id == updateCourseProgramRequest.Id);
            _mapper.Map(updateCourseProgramRequest, courseProgram);
            CourseProgram updateCourseProgram = await _courseProgramDal.UpdateAsync(courseProgram);
            UpdatedCourseProgramResponse updatedCourseProgramResponse = _mapper.Map<UpdatedCourseProgramResponse>(updateCourseProgram);
            return updatedCourseProgramResponse;
        }
    }
}
