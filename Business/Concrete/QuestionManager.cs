using AutoMapper;
using Business.Abstract;
using Business.DTOs.Questions;
using Business.DTOs.Questions;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionManager:IQuestionService
    {
        IQuestionDal _questionDal;
        IMapper _mapper;

        public QuestionManager(IQuestionDal questionDal, IMapper mapper)
        {
            _questionDal = questionDal;
            _mapper = mapper;
        }

        public async Task<CreatedQuestionResponse> Add(CreateQuestionRequest createQuestionRequest)
        {
            Question question = _mapper.Map<Question>(createQuestionRequest);
            Question createdQuestion = await _questionDal.AddAsync(question);
            CreatedQuestionResponse createdQuestionResponse = _mapper.Map<CreatedQuestionResponse>(createdQuestion);
            return createdQuestionResponse;
        }

        public async Task<DeletedQuestionResponse> Delete(DeleteQuestionRequest deleteQuestionRequest)
        {
            Question? question = await _questionDal.GetAsync(u => u.Id == deleteQuestionRequest.Id);
            await _questionDal.DeleteAsync(question);
            DeletedQuestionResponse deletedQuestionResponse = _mapper.Map<DeletedQuestionResponse>(question);
            return deletedQuestionResponse;
        }

        public async Task<IPaginate<GetListQuestionResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _questionDal.GetListAsync(
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListQuestionResponse>>(data);
            return result;
        }

        public async Task<UpdatedQuestionResponse> Update(UpdateQuestionRequest updateQuestionRequest)
        {
            Question? question = await _questionDal.GetAsync(u => u.Id == updateQuestionRequest.Id);
            _mapper.Map(updateQuestionRequest, question);
            Question updateQuestion = await _questionDal.UpdateAsync(question);
            UpdatedQuestionResponse updatedQuestionResponse = _mapper.Map<UpdatedQuestionResponse>(updateQuestion);
            return updatedQuestionResponse;
        }
    }
}
