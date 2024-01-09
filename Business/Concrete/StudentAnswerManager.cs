using AutoMapper;
using Business.Abstract;
using Business.DTOs.Cities;
using Business.DTOs.StudentAnswers;
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
    public class StudentAnswerManager: IStudentAnswerService
    {
        IStudentAnswerDal _studentAnswerDal;
        IMapper _mapper;

        public StudentAnswerManager(IStudentAnswerDal studentAnswerDal, IMapper mapper)
        {
            _studentAnswerDal = studentAnswerDal;
            _mapper = mapper;
        }

        public async Task<CreatedStudentAnswerResponse> Add(CreateStudentAnswerRequest createStudentAnswerRequest)
        {
            StudentAnswer studentAnswer = _mapper.Map<StudentAnswer>(createStudentAnswerRequest);
            StudentAnswer createdStudentAnswer = await _studentAnswerDal.AddAsync(studentAnswer);
            CreatedStudentAnswerResponse createdStudentAnswerResponse = _mapper.Map<CreatedStudentAnswerResponse>(createdStudentAnswer);
            return createdStudentAnswerResponse;
        }

        public async Task<DeletedStudentAnswerResponse> Delete(DeleteStudentAnswerRequest deleteStudentAnswerRequest)
        {
            StudentAnswer studentAnswer = _mapper.Map<StudentAnswer>(deleteStudentAnswerRequest);
            StudentAnswer deleteStudentAnswer = await _studentAnswerDal.DeleteAsync(studentAnswer);
            DeletedStudentAnswerResponse deleteStudentAnswerResponse = _mapper.Map<DeletedStudentAnswerResponse>(deleteStudentAnswer);
            return deleteStudentAnswerResponse;
        }

        public async Task<IPaginate<GetListStudentAnswerResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _studentAnswerDal.GetListAsync(include: a => a.Include(a => a.Student).
       Include(a => a.Question),
          index: pageRequest.PageIndex,
          size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListStudentAnswerResponse>>(data);
            return result;
        }

        public async Task<UpdatedStudentAnswerResponse> Update(UpdateStudentAnswerRequest updateStudentAnswerRequest)
        {
            StudentAnswer studentAnswer = _mapper.Map<StudentAnswer>(updateStudentAnswerRequest);
            StudentAnswer updateStudentAnswer = await _studentAnswerDal.UpdateAsync(studentAnswer);
            UpdatedStudentAnswerResponse updateStudentAnswerResponse = _mapper.Map<UpdatedStudentAnswerResponse>(updateStudentAnswer);
            return updateStudentAnswerResponse;
        }
    }
}
