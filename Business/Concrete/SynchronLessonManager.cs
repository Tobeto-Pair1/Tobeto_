using AutoMapper;
using Business.Abstract;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
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
    public class SynchronLessonManager : ISynchronLessonService
    {
        ISynchronLessonDal _synchronLessonDal;
        IMapper _mapper;

        public SynchronLessonManager(ISynchronLessonDal synchronLessonDal, IMapper mapper)
        {
            _synchronLessonDal = synchronLessonDal;
            _mapper = mapper;
        }

        public async Task<CreatedSynchronLessonResponse> Add(CreateSynchronLessonRequest createSynchronLessonRequest)
        {
            SynchronLesson synchronLesson = _mapper.Map<SynchronLesson>(createSynchronLessonRequest);
            SynchronLesson createdSynchronLesson = await _synchronLessonDal.AddAsync(synchronLesson);
            CreatedSynchronLessonResponse createdSynchronLessonResponse = _mapper.Map<CreatedSynchronLessonResponse>(createdSynchronLesson);
            return createdSynchronLessonResponse;
        }

        public async Task<DeletedSynchronLessonResponse> Delete(DeleteSynchronLessonRequest deleteSynchronLessonRequest)
        {
            SynchronLesson synchronLesson = _mapper.Map<SynchronLesson>(deleteSynchronLessonRequest);
            SynchronLesson deletedSynchronLesson = await _synchronLessonDal.DeleteAsync(synchronLesson);
            DeletedSynchronLessonResponse deletedSynchronLessonResponse = _mapper.Map<DeletedSynchronLessonResponse>(deletedSynchronLesson);
            return deletedSynchronLessonResponse;
        }

        public async Task<IPaginate<GetListSynchronLessonResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _synchronLessonDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListSynchronLessonResponse>>(data);
            return result;
        }

        public async Task<UpdatedSynchronLessonResponse> Update(UpdateSynchronLessonRequest updateSynchronLessonRequest)
        {
            SynchronLesson synchronLesson = _mapper.Map<SynchronLesson>(updateSynchronLessonRequest);
            SynchronLesson updatedSynchronLesson = await _synchronLessonDal.UpdateAsync(synchronLesson);
            UpdatedSynchronLessonResponse updatedSynchronLessonResponse = _mapper.Map<UpdatedSynchronLessonResponse>(updatedSynchronLesson);
            return updatedSynchronLessonResponse;
        }
    }
}
