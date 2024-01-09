using AutoMapper;
using Business.Abstract;
using Business.DTOs.AsyncLessonDetail;
using Business.DTOs.AsyncLessons;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AsyncLessonDetailManager :IAsyncLessonDetailService
    {
        IAsyncLessonDetailDal _asyncLessonDetailDal;
        IMapper _mapper;

        public AsyncLessonDetailManager(IAsyncLessonDetailDal asyncLessonDetailDal, IMapper mapper)
        {
            _asyncLessonDetailDal = asyncLessonDetailDal;
            _mapper = mapper;
        }

        public async Task<CreatedAsyncLessonDetailResponse> Add(CreateAsyncLessonDetailRequest createAsyncLessonDetailRequest)
        {
            AsyncLessonDetail asyncLessonDetail = _mapper.Map<AsyncLessonDetail>(createAsyncLessonDetailRequest);
            AsyncLessonDetail createdAsyncLessonDetail = await _asyncLessonDetailDal.AddAsync(asyncLessonDetail);
            CreatedAsyncLessonDetailResponse createdAsyncLessonDetailResponse = _mapper.Map<CreatedAsyncLessonDetailResponse>(createdAsyncLessonDetail);
            return createdAsyncLessonDetailResponse;
        }

        public async Task<DeletedAsyncLessonDetailResponse> Delete(DeleteAsyncLessonDetailRequest deleteAsyncLessonDetailRequest)
        {
            AsyncLessonDetail asyncLessonDetail = _mapper.Map<AsyncLessonDetail>(deleteAsyncLessonDetailRequest);
            AsyncLessonDetail deletedAsyncLessonDetail = await _asyncLessonDetailDal.DeleteAsync(asyncLessonDetail);
            DeletedAsyncLessonDetailResponse deletedAsyncLessonDetailResponse = _mapper.Map<DeletedAsyncLessonDetailResponse>(deletedAsyncLessonDetail);
            return deletedAsyncLessonDetailResponse;
        }

        public async Task<IPaginate<GetListAsyncLessonDetailResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _asyncLessonDetailDal.GetListAsync
                (include: l => l.Include(l => l.Manufacturer)
                .Include(l => l.Category)
                .Include(l => l.AsyncLesson)
                .Include(l => l.LessonLanguage)
                .Include(l => l.SubType),

            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListAsyncLessonDetailResponse>>(data);
            return result;
        }


        public async Task<UpdatedAsyncLessonDetailResponse> Update(UpdateAsyncLessonDetailRequest updateAsyncLessonDetailRequest)
        {
            AsyncLessonDetail asyncLessonDetail = _mapper.Map<AsyncLessonDetail>(updateAsyncLessonDetailRequest);
            AsyncLessonDetail updatedAsyncLessonDetail = await _asyncLessonDetailDal.UpdateAsync(asyncLessonDetail);
            UpdatedAsyncLessonDetailResponse updatedAsyncLessonDetailResponse = _mapper.Map<UpdatedAsyncLessonDetailResponse>(updatedAsyncLessonDetail);
            return updatedAsyncLessonDetailResponse;
        }
    }
}
