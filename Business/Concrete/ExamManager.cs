using AutoMapper;
using Business.Abstract;
using Business.DTOs.Cities;
using Business.DTOs.Exams;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExamManager:IExamService
    {
        IExamDal _examDal;
        IMapper _mapper;

        public ExamManager(IExamDal examDal, IMapper mapper)
        {
            _examDal = examDal;
            _mapper = mapper;
        }

        public async Task<CreatedExamResponse> Add(CreateExamRequest createExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(createExamRequest);
            Exam createdExam = await _examDal.AddAsync(exam);
            CreatedExamResponse createdExamResponse = _mapper.Map<CreatedExamResponse>(createdExam);
            return createdExamResponse;
        }

        public async Task<DeletedExamResponse> Delete(DeleteExamRequest deleteExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(deleteExamRequest);
            Exam deleteExam = await _examDal.DeleteAsync(exam);
            DeletedExamResponse deleteExamResponse = _mapper.Map<DeletedExamResponse>(deleteExam);
            return deleteExamResponse;
        }

        public async Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _examDal.GetListAsync(
      
          index: pageRequest.PageIndex,
          size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListExamResponse>>(data);
            return result;
        }

        public async Task<UpdatedExamResponse> Update(UpdateExamRequest updateExamRequest)
        {
            Exam exam = _mapper.Map<Exam>(updateExamRequest);
            Exam updateExam = await _examDal.UpdateAsync(exam);
            UpdatedExamResponse updateExamResponse = _mapper.Map<UpdatedExamResponse>(updateExam);
            return updateExamResponse;
        }
    }
}
