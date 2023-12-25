using AutoMapper;
using Business.Abstract;
using Business.DTOs.SynchronLessonInstructors;
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
    public class SynchronLessonInstructorManager : ISynchronLessonInstructorService
    {
        ISynchronLessonInstructorDal _synchronLessonInstructorDal;
        IMapper _mapper;

        public SynchronLessonInstructorManager(ISynchronLessonInstructorDal synchronLessonInstructorDal, IMapper mapper)
        {
            _synchronLessonInstructorDal = synchronLessonInstructorDal;
            _mapper = mapper;
        }

        public async Task<CreatedSynchronLessonInstructorResponse> Add(CreateSynchronLessonInstructorRequest createSynchronLessonInstructorRequest)
        {
            SynchronLessonInstructor synchronLessonInstructor = _mapper.Map<SynchronLessonInstructor>(createSynchronLessonInstructorRequest);
            SynchronLessonInstructor createdSynchronLessonInstructor = await _synchronLessonInstructorDal.AddAsync(synchronLessonInstructor);
            CreatedSynchronLessonInstructorResponse createdSynchronLessonInstructorResponse = _mapper.Map<CreatedSynchronLessonInstructorResponse>(createdSynchronLessonInstructor);
            return createdSynchronLessonInstructorResponse;
        }

        public async Task<DeletedSynchronLessonInstructorResponse> Delete(DeleteSynchronLessonInstructorRequest deleteSynchronLessonInstructorRequest)
        {
            SynchronLessonInstructor synchronLessonInstructor = _mapper.Map<SynchronLessonInstructor>(deleteSynchronLessonInstructorRequest);
            SynchronLessonInstructor deletedSynchronLessonInstructor = await _synchronLessonInstructorDal.DeleteAsync(synchronLessonInstructor);
            DeletedSynchronLessonInstructorResponse deletedSynchronLessonInstructorResponse = _mapper.Map<DeletedSynchronLessonInstructorResponse>(deletedSynchronLessonInstructor);
            return deletedSynchronLessonInstructorResponse;
        }

        public async Task<IPaginate<GetListSynchronLessonInstructorResponse>> GetListAsync(PageRequest pageRequest)
        {

            var data = await _synchronLessonInstructorDal.GetListAsync(include: a => a.Include(a => a.Instructor).
            Include(a => a.SynchronLesson),
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListSynchronLessonInstructorResponse>>(data);
            return result;
        }

        public async Task<UpdatedSynchronLessonInstructorResponse> Update(UpdateSynchronLessonInstructorRequest updateSynchronLessonInstructorRequest)
        {
            SynchronLessonInstructor synchronLessonInstructor = _mapper.Map<SynchronLessonInstructor>(updateSynchronLessonInstructorRequest);
            SynchronLessonInstructor updatedSynchronLessonInstructor = await _synchronLessonInstructorDal.UpdateAsync(synchronLessonInstructor);
            UpdatedSynchronLessonInstructorResponse updatedSynchronLessonInstructorResponse = _mapper.Map<UpdatedSynchronLessonInstructorResponse>(updatedSynchronLessonInstructor);
            return updatedSynchronLessonInstructorResponse;
        }
    }
}
