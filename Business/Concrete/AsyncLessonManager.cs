using AutoMapper;
using Business.Abstract;
using Business.DTOs.AsyncLessons;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AsyncLessonManager : IAsyncLessonService
    {
        IAsyncLessonDal _asyncLessonDal;
        IMapper _mapper;

        public AsyncLessonManager(IAsyncLessonDal asyncLessonDal, IMapper mapper)
        {
            _asyncLessonDal = asyncLessonDal;
            _mapper = mapper;
        }

        public async Task<CreatedAsyncLessonResponse> Add(CreateAsyncLessonRequest createAsyncLessonRequest)
        {
            AsyncLesson asyncLesson = _mapper.Map<AsyncLesson>(createAsyncLessonRequest);
            AsyncLesson createdAsyncLesson = await _asyncLessonDal.AddAsync(asyncLesson);
            CreatedAsyncLessonResponse createdAsyncLessonResponse = _mapper.Map<CreatedAsyncLessonResponse>(createdAsyncLesson);
            return createdAsyncLessonResponse;
        }

        public async Task<DeletedAsyncLessonResponse> Delete(DeleteAsyncLessonRequest deleteAsyncLessonRequest)
        {
            AsyncLesson asyncLesson = _mapper.Map<AsyncLesson>(deleteAsyncLessonRequest);
            AsyncLesson deletedAsyncLesson = await _asyncLessonDal.AddAsync(asyncLesson);
            DeletedAsyncLessonResponse deletedAsyncLessonResponse = _mapper.Map<DeletedAsyncLessonResponse>(deletedAsyncLesson);
            return deletedAsyncLessonResponse;
        }

        public async Task<IPaginate<GetListAsyncLessonResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _asyncLessonDal.GetListAsync(include: l => l.Include(l => l.CourseModule).Include(l=>l.Instructor),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListAsyncLessonResponse>>(data);
            return result;
        }



        public async Task<UpdatedAsyncLessonResponse> Update(UpdateAsyncLessonRequest updateAsyncLessonRequest)
        {
            AsyncLesson asyncLesson = _mapper.Map<AsyncLesson>(updateAsyncLessonRequest);
            AsyncLesson updatedAsyncLesson = await _asyncLessonDal.AddAsync(asyncLesson);
            UpdatedAsyncLessonResponse updatedAsyncLessonResponse = _mapper.Map<UpdatedAsyncLessonResponse>(updatedAsyncLesson);
            return updatedAsyncLessonResponse;
        }
    }
}
