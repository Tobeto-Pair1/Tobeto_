using AutoMapper;
using Business.Abstract;
using Business.DTOs.AsyncLessonDetail;
using Business.DTOs.AsyncLessons;
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
            AsyncLessonDetail? asyncLessonDetail = await _asyncLessonDetailDal.GetAsync(u => u.Id == deleteAsyncLessonDetailRequest.Id);
            await _asyncLessonDetailDal.DeleteAsync(asyncLessonDetail);
            DeletedAsyncLessonDetailResponse deletedAsyncLessonDetailResponse = _mapper.Map<DeletedAsyncLessonDetailResponse>(asyncLessonDetail);
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
            AsyncLessonDetail? asyncLessonDetail = await _asyncLessonDetailDal.GetAsync(u => u.Id == updateAsyncLessonDetailRequest.Id);
            _mapper.Map(updateAsyncLessonDetailRequest, asyncLessonDetail);
            AsyncLessonDetail updateAsyncLessonDetail = await _asyncLessonDetailDal.UpdateAsync(asyncLessonDetail);
            UpdatedAsyncLessonDetailResponse updatedAsyncLessonDetailResponse = _mapper.Map<UpdatedAsyncLessonDetailResponse>(updateAsyncLessonDetail);
            return updatedAsyncLessonDetailResponse;
        }
    }
}
