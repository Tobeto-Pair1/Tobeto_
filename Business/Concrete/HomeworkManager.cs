using AutoMapper;
using Business.Abstract;
using Business.DTOs.Homeworks;
using Business.DTOs.Homeworks;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HomeworkManager : IHomeworkService
    {

        IHomeworkDal _homeworkDal;
        IMapper _mapper;

        public HomeworkManager(IHomeworkDal homeworkDal, IMapper mapper)
        {
            _homeworkDal = homeworkDal;
            _mapper = mapper;
        }

        public async Task<CreatedHomeworkResponse> Add(CreateHomeworkRequest createHomeworkRequest)
        {
            Homework homework = _mapper.Map<Homework>(createHomeworkRequest);
            Homework createdHomework = await _homeworkDal.AddAsync(homework);
            CreatedHomeworkResponse createdHomeworkResponse = _mapper.Map<CreatedHomeworkResponse>(createdHomework);

            return createdHomeworkResponse;
        }

        public async Task<DeletedHomeworkResponse> Delete(DeleteHomeworkRequest deleteHomeworkRequest)
        {
            Homework? homework = await _homeworkDal.GetAsync(u => u.Id == deleteHomeworkRequest.Id);
            await _homeworkDal.DeleteAsync(homework);
            DeletedHomeworkResponse deletedHomeworkResponse = _mapper.Map<DeletedHomeworkResponse>(homework);
            return deletedHomeworkResponse;
        }

        public async Task<IPaginate<GetListHomeworkResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _homeworkDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
            var result = _mapper.Map<Paginate<GetListHomeworkResponse>>(data);

            return result;
        }

        public async Task<UpdatedHomeworkResponse> Update(UpdateHomeworkRequest updateHomeworkRequest)
        {
            Homework? homework = await _homeworkDal.GetAsync(u => u.Id == updateHomeworkRequest.Id);
            _mapper.Map(updateHomeworkRequest, homework);
            Homework updateHomework = await _homeworkDal.UpdateAsync(homework);
            UpdatedHomeworkResponse updatedHomeworkResponse = _mapper.Map<UpdatedHomeworkResponse>(updateHomework);
            return updatedHomeworkResponse;
        }
    }
}
